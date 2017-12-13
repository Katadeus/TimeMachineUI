using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDifferenceCalculator : MonoBehaviour {

    public int timeDifference = 0; // In days
    public int timeDiffDays = 0;
    public GameObject NY; //new year
    public GameObject NM; //new month
    public GameObject ND; //new day
    public GameObject NE; //new era
    public GameObject OY; //old year
    public GameObject OM; //old month
    public GameObject OD; //old day
    public GameObject OE; //old era
    public GameObject DY; //difference year
    public GameObject DM; //difference month
    public GameObject DD; //difference day
    public GameObject PM; //forward or back in time

    // Use this for initialization
    void Start () {
        timeDifference = 0;	
	}
	

    void Update()
    {
        timeDifference = 0;
        timeDifference += NY.GetComponent<DigitsAggregator>().number * 365 + NM.GetComponent<DigitsAggregator>().number * 30 + ND.GetComponent<DigitsAggregator>().number;
        timeDifference -= OY.GetComponent<StaticDigitsAggregator>().number * 365 + OM.GetComponent<StaticDigitsAggregator>().number * 30 + OD.GetComponent<StaticDigitsAggregator>().number;
        if (!OE.GetComponent<ToggleButtonScript>().boo && NE.GetComponent<ToggleButtonScript>().boo)
        {
            PM.GetComponent<ToggleButtonScript>().Set(true);
            timeDifference = Mathf.Abs(timeDifference);
        }
        else if (OE.GetComponent<ToggleButtonScript>().boo && !NE.GetComponent<ToggleButtonScript>().boo)
        {
            PM.GetComponent<ToggleButtonScript>().Set(false);
            timeDifference = Mathf.Abs(timeDifference);
        }
        else if (timeDifference < 0)
        {
            PM.GetComponent<ToggleButtonScript>().Set(false);
            timeDifference = Mathf.Abs(timeDifference);
        }
        else if (timeDifference > 0)
        {
            PM.GetComponent<ToggleButtonScript>().Set(true);
            timeDifference = Mathf.Abs(timeDifference);
        }
        timeDiffDays = timeDifference;
        DY.GetComponent<StaticDigitsAggregator>().number = timeDifference/365;
        timeDifference %= 365;
        DM.GetComponent<StaticDigitsAggregator>().number = timeDifference/30;
        timeDifference %= 30;
        DD.GetComponent<StaticDigitsAggregator>().number = timeDifference;
    }
}
