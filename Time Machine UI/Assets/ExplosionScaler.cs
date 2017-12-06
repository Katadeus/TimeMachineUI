using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionScaler : MonoBehaviour {

    public Slider slider;
    public RectTransform rectTransform;

	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slider.value * 8);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slider.value * 8);
	}
}
