﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonScript : MonoBehaviour {

    public bool boo = true;
    public string on = "";
    public string off = "";
    public GameObject child;

	// Use this for initialization
	void Start () {
        child = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Switch () {
        boo = !boo;
        if (boo)
        {
            child.GetComponent<Text>().text = on;
        }
        else
        {
            child.GetComponent<Text>().text = off;
        }
    }
}
