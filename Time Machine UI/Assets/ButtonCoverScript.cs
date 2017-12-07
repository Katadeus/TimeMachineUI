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
		if (active)
        {
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
            else
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

    public void Scale () {
        on = !on;
        active = true;
    }
}
