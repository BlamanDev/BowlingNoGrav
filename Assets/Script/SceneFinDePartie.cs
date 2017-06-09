using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneFinDePartie : MonoBehaviour {
    public GameObject GOmanager;
    Manager manager;
    public Text Score;
	// Use this for initialization
	void Start () {
        GOmanager = GameObject.Find("Manager");
        manager = GOmanager.GetComponent<Manager>();

        Score.text = manager.Score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
