using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltitudeManager : MonoBehaviour {

    public GameObject intAltDigits;
    public GameObject currAltDigits;
    public GameObject parachuteButton;

    public int targetAltitude;
    public float currentAltitude;

    public int groundLevel;

    public bool parachute;

    private float velocity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Get target
        targetAltitude = intAltDigits.GetComponent<DigitsAggregator>().number;

        // Get parachute
        parachute = parachuteButton.GetComponent<Toggle>().isOn;

        // Handle falling
        if(currentAltitude > groundLevel)
        {
            // Gravity
            velocity -= 32.2f * Time.deltaTime;
            // Air resistance
            //if (parachute)
            //{
            //    velocity *= 0.97f;
            //}
            //else
            //{
            //    velocity *= 0.999f;
            //}
            if (parachute)
            {
                // More addition based on how far from -1 it is
                if (velocity < -1)
                {
                    velocity += (-1 - velocity) * 6 * Time.deltaTime;
                }
            }

            currentAltitude += velocity * Time.deltaTime;
        }

        // Set current
        currAltDigits.GetComponent<StaticDigitsAggregator>().number = Mathf.RoundToInt(currentAltitude);
	}

    public void Jump () {
        currentAltitude = targetAltitude;
    }
}
