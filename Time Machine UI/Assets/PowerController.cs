using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerController : MonoBehaviour {

    public GameObject timeDiffPanel;
    public float power;             // Ranges from 0 to 120
    public float powerDemand;       // 10000 years = 120
    public GameObject powerBar;
    public GameObject powerDemandBar;
    private float tempPower;
    public float tempPowerDemand;
    public float rate = 20000;
    public Color normalDemand;
    public Color dangerDemand;
    public Color overDemand;
    public Image demandImage;
    public GameObject noReturnThing;

	// Use this for initialization
	void Start () {
        demandImage = powerDemandBar.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        powerDemand = timeDiffPanel.GetComponent<TimeDifferenceCalculator>().timeDifference;
        tempPower -= (tempPower - power) * 2 * Time.deltaTime;
        if (tempPower > 120)
        {
            tempPower = 120;
        }
        powerBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tempPower);
        tempPowerDemand -= (tempPowerDemand - powerDemand/rate) * 10 * Time.deltaTime;
        if (tempPowerDemand < power / 2)
        {
            noReturnThing.GetComponent<NoReturnScript>().on = false;
            demandImage.CrossFadeColor(normalDemand, 0.5f, false, true);
        }
        else
        {
            noReturnThing.GetComponent<NoReturnScript>().on = true;
            if (tempPowerDemand > power)
            {
                // Red light
                demandImage.CrossFadeColor(overDemand, 0.5f, false, true);
                tempPowerDemand = tempPower;
            }
            else
            {
                demandImage.CrossFadeColor(dangerDemand, 0.5f, false, true);
            }
        }
        if (tempPowerDemand > tempPower)
        {
            tempPowerDemand = tempPower;
        }
        if (tempPowerDemand < 0)
        {
            tempPowerDemand = 0;
        }
        if (tempPowerDemand == 0)
        {
            powerDemandBar.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            powerDemandBar.transform.localScale = new Vector3(1, 1, 1);
        }

        powerDemandBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tempPowerDemand);
	}
}
