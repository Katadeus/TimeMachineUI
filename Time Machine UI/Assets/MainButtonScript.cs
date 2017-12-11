using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonScript : MonoBehaviour {

    public GameObject CurrentTimePanel;
    public GameObject TargetTimeYMDPanel;
    public GameObject CurrentADBCE;
    public GameObject TargetADBCE;
    public GameObject AltitudeManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TimeTravel () {

        // Set year, month and date
        CurrentTimePanel.GetComponent<CurrentTimeAggregator>().y = TargetTimeYMDPanel.GetComponent<TargetTimeAggregator>().y;
        CurrentTimePanel.GetComponent<CurrentTimeAggregator>().m = TargetTimeYMDPanel.GetComponent<TargetTimeAggregator>().m;
        CurrentTimePanel.GetComponent<CurrentTimeAggregator>().d = TargetTimeYMDPanel.GetComponent<TargetTimeAggregator>().d;
        CurrentTimePanel.GetComponent<CurrentTimeAggregator>().Refresh(); // Setting number isn't enough - need to update interface

        // Set AD/BCE button
        CurrentADBCE.GetComponent<ToggleButtonScript>().Set(TargetADBCE.GetComponent<ToggleButtonScript>().boo);

        // Set altitude
        AltitudeManager.GetComponent<AltitudeManager>().Jump();

    }
}
