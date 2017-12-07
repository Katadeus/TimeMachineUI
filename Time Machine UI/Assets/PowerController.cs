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
	
    // Update the size of the power bar and power demand bar
	void Update () {

        // This code is complicated by the desire to move the bars over time. The power and powerDemand variables move instantly.
        // The tempPower and tempPowerDemand variables move over time.
        
        // Here, we move the tempPower variable, as it is the most straightforward action.
        tempPower -= (tempPower - power) * 2 * Time.deltaTime;

        // This bar cannot exceed 120. If power is greater than 120, this information will not be represented.
        if (tempPower > 120)
        {
            tempPower = 120;
        }

        // Nothing else needs doing here, so we can scale the power panel.
        powerBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tempPower);


        // Power demand requires a bit more work.
        powerDemand = timeDiffPanel.GetComponent<TimeDifferenceCalculator>().timeDifference;

        // Temp power approaches powerDemand/rate. PowerDemand is expressed as the length of travel in days.
        tempPowerDemand -= (tempPowerDemand - powerDemand/rate) * 10 * Time.deltaTime;

        // Check if power demand is greater than half of remaining power reserve. This checks whether a return trip is possible.
        if (tempPowerDemand < power / 2)
        {
            noReturnThing.GetComponent<NoReturnScript>().on = false;
            demandImage.CrossFadeColor(normalDemand, 0.5f, false, true);
        }
        else // If it isn't less than half, start making some visual noise.
        {
            noReturnThing.GetComponent<NoReturnScript>().on = true;

            // If it's more than total power available, really yell
            if (tempPowerDemand > power)
            {
                // Red light
                demandImage.CrossFadeColor(overDemand, 0.5f, false, true);

            }
            else
            {
                // Orange light
                demandImage.CrossFadeColor(dangerDemand, 0.5f, false, true);
            }
        }

        // Some more miscellaneous checks
        if (tempPowerDemand > tempPower)
        {   // Make sure it doesn't scale over the size of the available power bar - we don't want it to leave the container.
            tempPowerDemand = tempPower;
        }
        if (tempPowerDemand < 0)
        {   // Make sure it doesn't go up outside of the box (this could use a bit of work for the smallest-scale ones because they misshape themselves.)
            tempPowerDemand = 0;
        }
        if (tempPowerDemand == 0)
        {   // Don't show this bar at all if it's at 0 (for some reason unity insists on drawing a y Size 0 panel as a short misplaced line.)
            powerDemandBar.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {   // Otherwise display the bar as normal.
            powerDemandBar.transform.localScale = new Vector3(1, 1, 1);
        }

        // Now that all that trouble is out of the way, change the size of the bar.
        powerDemandBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tempPowerDemand);
	}
}
