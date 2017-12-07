using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTimeAggregator : MonoBehaviour {

    public int y;
    public int m;
    public int d;

    public GameObject yearDigits;
    public GameObject monthDigits;
    public GameObject dayDigits;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GrabDigits();
	}

    // Everything in this script is controlled externally. It exists as a halfway point. The only operation it performs is to actually convey numbers.
    // This script's conveyance is to take digits from the interface.
    void GrabDigits () {
        y = yearDigits.GetComponent<DigitsAggregator>().number;
        m = monthDigits.GetComponent<DigitsAggregator>().number;
        d = dayDigits.GetComponent<DigitsAggregator>().number;

    }
}
