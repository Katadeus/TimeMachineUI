using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberScript : MonoBehaviour {

    public int i;
    private Text numField;

	// Use this for initialization
	void Start () {
        numField = GetComponent<Text>();
	}
	
	// Set the number's text
	void Update () {
        numField.text = i.ToString();
	}
}
