using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public float acceleration = 1;
    public Text countText;
    public Text winTexte;
    public Text axeH;
    public Text axeV;
    public bool GyroActif = false;
    public bool tempsDemarrer = false;
    public AudioClip sonCollision = new AudioClip();
    public Joystick joy;

    public GameObject GOmanager;
    private Manager manager;


    // Use this for initialization
    void Start()
    {
        winTexte.text = "";

        manager = GOmanager.GetComponent<Manager>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        manager.Score = 0;

    }

    private void setCountText()
    {

        countText.text = "Cubes : " + manager.Score.ToString();
        if (GameObject.FindGameObjectsWithTag("Collectible").Length <= 0)
        {
            winTexte.text = "Gagné !";
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {
     
        axeH.text = acceleration.ToString();
        GestionInput();
  
    }

    //Collision avec un objet declencheur
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vide")
        {
            Debug.Log("Vous avez perdu !");
            new Recommencer().recommencer();
        }
    }

    //Collision
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Cube")
        {
            manager.PremiereCollision();
            GetComponent<AudioSource>().PlayOneShot(sonCollision);
        }
        

    }

    private void GestionInput()
    {
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
        //SI le systeme a un gyroscope ET une touche sur l'ecran est detectée
        /*if ((SystemInfo.supportsGyroscope) && (Input.touchCount > 0))
        {
            this.activerGyro();
        }
        */
        #region  Gestion de l'acceleration
        //SI Une direction est appuyée, augmentation de l'accelaration
        if ((CrossPlatformInputManager.GetAxis("Horizontal") != 0) || (CrossPlatformInputManager.GetAxis("Vertical") != 0))
        {
            if (acceleration < 6) acceleration += 0.1f;
        }
        //SINON remise a 1 de l'accelaration
        else
        {
            acceleration = 1;
        }
        #endregion

        #region gestion du mouvement
        float mouveHorizontal = 0;
        float mouveVertical = 0;

        //SI gyroscope actif ALORS récupération du mouvement du gyroscope
        if (GyroActif)
        {
            mouveHorizontal = Input.gyro.attitude.y * 6;
            mouveVertical = -Input.gyro.attitude.x * 5;
        }
        //SINON récupération de la direction appuyée
        else
        {
            
            mouveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            mouveVertical = CrossPlatformInputManager.GetAxis("Vertical");
           // mouveHorizontal = Input.GetAxis("Horizontal");
           // mouveVertical = Input.GetAxis("Vertical");
        }

        appliquerMouvement(mouveHorizontal, mouveVertical);
        #endregion


    }

    /// <summary>
    /// Applique le mouvement au Player
    /// </summary>
    /// <param name="mouveHorizontal"></param>
    /// <param name="mouveVertical"></param>
    /// <param name="mouveHauteur"></param>
    private void appliquerMouvement(float mouveHorizontal,  float mouveVertical, float mouveHauteur=0)
    {
        //Creation du nouveau mouvement
        Vector3 mouvement = new Vector3(mouveHorizontal, mouveHauteur, mouveVertical);

        //récupération du du RigidBody player
        Rigidbody body = GetComponent<Rigidbody>();
        //Ajout du mouvement
        body.AddForce(mouvement * speed * Time.deltaTime * acceleration);
    }

    /// <summary>
    /// Active le gyroscope
    /// </summary>
    private void activerGyro()
    {
        Gyroscope gyo1 = Input.gyro;
        gyo1.enabled = true;
        GyroActif = true;
    }


}
