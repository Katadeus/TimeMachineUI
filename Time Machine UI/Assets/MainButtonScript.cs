using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonScript : MonoBehaviour {

    public GameObject CurrentTimePanel;
    public GameObject TargetTimeYMDPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TimeTravel () {
        CurrentTimePanel.GetComponent<CurrentTimeAggregator>().y = TargetTimeYMDPanel.GetComponent<TargetTimeAggregator>().y;
        CurrentTimePanel.GetComponent<CurrentTimeAggregator>().m = TargetTimeYMDPanel.GetComponent<TargetTimeAggregator>().m;
        CurrentTimePanel.GetComponent<CurrentTimeAggregator>().d = TargetTimeYMDPanel.GetComponent<TargetTimeAggregator>().d;
        CurrentTimePanel.GetComponent<CurrentTimeAggregator>().Refresh();
    }
}
