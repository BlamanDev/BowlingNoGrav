using Assets.BO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CubeScore : MonoBehaviour
{
    
    public GameObject GOmanager;
    private Manager manager;
    

    public Text Score;

    // Use this for initialization
    void Start()
    {
        GOmanager = GameObject.Find("Manager");
        manager = GOmanager.GetComponent<Manager>();
        
        
    }



    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag=="Mur")
        {
            manager.Score++;
            
        }
        
        setCountText();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Limite")
        {
            this.gameObject.SetActive(false);
        }
    }

    private void setCountText()
    {
        Score.text = "Score : " + manager.Score.ToString();

    }
}