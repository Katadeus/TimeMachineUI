using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDigitsAggregator : MonoBehaviour {

    public int number;
    public int numDigits;
    public GameObject prefab;
    public List<GameObject> digits;
    private GameObject temp;
    public int width = 75;
    private int tempDigit;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numDigits; i++)
        {
            temp = Instantiate<GameObject>(prefab);
            temp.transform.name = "Digit " + i.ToString();
            temp.transform.SetParent(transform);
            temp.transform.localPosition = new Vector3(width / numDigits * i - width / 2 + (width / numDigits) / 2, 0, 0);
            tempDigit = (int)(number / Mathf.Pow(10, numDigits - i - 1));
            for(int x = 0; x < 4; x++) {
                tempDigit = (int)(tempDigit - Mathf.Pow(10, x + 1) * (int)(tempDigit / Mathf.Pow(10, x + 1)));
            }
            temp.GetComponent<NumberScript>().i = tempDigit;
            digits.Add(temp);
        }
	}
	
	// Update is called once per frame
	void Update () {
        number = 0;
		for (int i = 0; i < numDigits; i++)
        {
            number += digits[i].GetComponent<NumberScript>().i * Mathf.RoundToInt(Mathf.Pow(10,numDigits - i - 1));
        }
	}
}
