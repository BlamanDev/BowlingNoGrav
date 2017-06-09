using UnityEngine;
using System.Collections;

public class Recommencer : MonoBehaviour {

	

    public void recommencer()
    {
        DestroyObject(GameObject.Find("Manager"));
        Application.LoadLevel(0);
    }
}
