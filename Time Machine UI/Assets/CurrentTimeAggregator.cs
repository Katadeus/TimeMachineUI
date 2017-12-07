using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTimeAggregator : MonoBehaviour {

    public int y;
    public int m;
    public int d;

    public GameObject yearDigits;
    public GameObject monthDigits;
    public GameObject dayDigits;

	// Use this for initialization
	void Start () {
        Refresh();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Refresh () {
        yearDigits.GetComponent<StaticDigitsAggregator>().number = y;
        monthDigits.GetComponent<StaticDigitsAggregator>().number = m;
        dayDigits.GetComponent<StaticDigitsAggregator>().number = d;
    }
}
