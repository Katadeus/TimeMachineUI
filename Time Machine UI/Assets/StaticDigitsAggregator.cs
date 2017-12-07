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

        // Set up the list of digits
		for (int i = 0; i < numDigits; i++)
        {
            temp = Instantiate<GameObject>(prefab);
            temp.transform.name = "Digit " + i.ToString();
            temp.transform.SetParent(transform);
            temp.transform.localPosition = new Vector3(width / numDigits * i - width / 2 + (width / numDigits) / 2, 0, 0);

            // Here's where it gets hairy.
            // The tempDigit starts by cutting off as many digits from the end of the number as it can. Initially for a four digit number, you want to cut off
            // the three last digits to yield the first.
            // The next digit of a four-digit number needs more attention, as simply cutting off digits from the end still yields a two digit number.
            tempDigit = (int)(number / Mathf.Pow(10, numDigits - i - 1));
            // The next action can cut off up to four digits from the top.
            // Each of these iterations cuts off exactly one digit (I think.)
            // I don't know any more about this than that because I coded this very late at night and it works perfectly in every case I have given it.
            // There might be a simpler way to do this, but I don't want to risk it (converting to a string loses data - grabbing the second character could
            // yield several different places depending on how many zeroes are on the front of your number.
            for(int x = 0; x < 4; x++) {
                tempDigit = (int)(tempDigit - Mathf.Pow(10, x + 1) * (int)(tempDigit / Mathf.Pow(10, x + 1)));
            }
            // At this point, the tempDigit should be just one digit.
            temp.GetComponent<NumberScript>().i = tempDigit;
            digits.Add(temp);
        }
	}
	
	// Update is called once per frame
	void Update () {

        // Go through the number and extract each digit
        // Since this is the static, uninteractable section, we don't want to take information from the interface; we want to send info TO it.
        for (int i = 0; i < numDigits; i++)
        {
            // The same single-digit extraction math has to happen here.
            tempDigit = (int)(number / Mathf.Pow(10, numDigits - i - 1));
            for(int x = 0; x < 4; x++) {
                tempDigit = (int)(tempDigit - Mathf.Pow(10, x + 1) * (int)(tempDigit / Mathf.Pow(10, x + 1)));
            }
            digits[i].GetComponent<NumberScript>().i = tempDigit;
        }
	}
}
