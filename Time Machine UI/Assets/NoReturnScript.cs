using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoReturnScript : MonoBehaviour {

    public bool on = false;
    public Text textField;
    public Color red;
    public Color normal;

	// Use this for initialization
	void Start () {
        textField = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (on)
        {
            textField.color = red;
        }
        else
        {
            textField.color = normal;
        }
	}
}
