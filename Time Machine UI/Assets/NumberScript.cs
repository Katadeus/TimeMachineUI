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
	
	// Update is called once per frame
	void Update () {
        numField.text = i.ToString();
	}
}
