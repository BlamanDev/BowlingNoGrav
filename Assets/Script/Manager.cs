using UnityEngine;
using System.Collections;
using System;

public class Manager : MonoBehaviour {
    private int score=0;
    private  bool depart = false;
    private DateTime tempsDepart;
    
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public int Temps
    {
        get
        {
            return DateTime.Now.Subtract(tempsDepart).Seconds;
        }

    }

    public String TempsAffiche
    {
        get
        {
            return (10 - Temps).ToString(); ;
        }
    }

    public bool Depart
    {
        get
        {
            return depart;
        }

        set
        {
            depart = value;
        }
    }

   

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PremiereCollision()
    {
        if (!Depart)
        {
            tempsDepart = DateTime.Now;
            
            Depart = true;
        }
    }

   


}
