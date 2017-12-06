using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoReturnScript : MonoBehaviour {

    public bool on = false;
    public Text textField;
    public Color red;
    public Color normal;
    public Color panelNormal;
    public Color panelRed;
    public float bouncer = 0;
    private bool lastState = false;

	// Use this for initialization
	void Start () {
        textField = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (on)
        {
            if (!lastState)
            {
                bouncer = 0;
                GetComponent<Image>().CrossFadeColor(panelRed, 1.5f, false, false);
            }
            textField.color = red;
            bouncer += Time.deltaTime;
            if (bouncer > 1.5f && bouncer < 3)
            {
                bouncer += 1.5f;
                GetComponent<Image>().CrossFadeColor(panelNormal, 1.5f, false, false);
            }
            else if (bouncer > 4.5f || bouncer <= 0)
            {
                bouncer -= 4.5f;
                GetComponent<Image>().CrossFadeColor(panelRed, 1.5f, false, false);
            }
        }
        else
        {
            textField.color = normal;
            GetComponent<Image>().CrossFadeColor(panelNormal, 1.5f, false, false);
        }
        lastState = on;
	}
}