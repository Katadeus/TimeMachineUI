using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCoverScript : MonoBehaviour {

    public bool on = true;
    public bool active = false;
    public float yScale = 80;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Check if things need to be moving, then move them.
		if (active)
        {   // If it's supposed to be on, scale it upward.
            if (on)
            {
                if (yScale < 80)
                {
                    yScale += 70 * Time.deltaTime;
                }
                else
                {
                    yScale = 80;
                    active = false;
                }
            }
            else // Otherwise, scale it downward.
            {
                if (yScale > 10)
                {
                    yScale -= 70 * Time.deltaTime;
                }
                else
                {
                    yScale = 10;
                    active = false;
                }
            }
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, yScale);
        }
	}

    // All that has to happen here is to switch its state and turn it on.
    public void Scale () {
        on = !on;
        active = true;
    }
}
