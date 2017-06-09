using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderScript : MonoBehaviour {
    public Slider sliderTemps;
    public InputField inputTemps;

	// Use this for initialization
	void Start () {

        

    }
	
    public void afficheCompteur()
    {
        inputTemps = this.GetComponent<InputField>();
        inputTemps.text = sliderTemps.value.ToString();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
