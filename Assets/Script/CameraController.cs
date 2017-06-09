using UnityEngine;
using System.Collections;
using Assets.BO;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    public GameObject Player;
    private Vector3 offset;
    public Text AfficheurTemps;
    public GameObject GOmanager;
    private Manager manager;
    

    // Use this for initialization
    void Start()
    {
        offset = transform.position - Player.transform.position ;
       manager = GOmanager.GetComponent<Manager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = Player.transform.position + offset;
        if (manager.Depart)
        {
            AfficheurTemps.text = manager.TempsAffiche;
            if (manager.Temps > 10)
            {
                Application.LoadLevel(1);
            }
        }

    }
}
