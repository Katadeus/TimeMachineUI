using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWheelScript : MonoBehaviour {

    public int number = 0;
    public float scale = 0;
    public float offset = -500;
    public float rate = 1;

	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(0, offset);
	}
	
	// Update is called once per frame
	void Update () {
        if (number > 9) { number = 9; }
        if (number < 0) { number = 0; }
		if (Mathf.Abs(transform.localPosition.y - (offset + number * scale)) > 0.01)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y - (transform.localPosition.y - (offset + number * scale)) * rate * Time.deltaTime);
        }
        else { transform.localPosition = new Vector3(0, offset + number * scale, 0); }
	}
}
