﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButtonScript : MonoBehaviour {

    public int i = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Move the value up
    public void Up () {
        i++;
        if (i > 9) { i -= 10; }
        GetComponent<Text>().text = i.ToString();
    }

    // Move the value down
    public void Down () {
        i--;
        if (i < 0) { i += 10; }
        GetComponent<Text>().text = i.ToString();
    }
}
