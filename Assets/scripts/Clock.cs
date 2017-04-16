using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

	public float speed = 1f;
	DateTime date;
	float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
		string iDate = "10/01/1914";	
		date = Convert.ToDateTime(iDate);
	}

	public DateTime getDate() {
		return date;
	}

	void AdvanceTime(int hours) {
		TimeSpan time = new TimeSpan(1, 0, 0);
		date = date.Add(time);
	}

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (speed == 0f)
			return;
		if (elapsedTime > (10f/speed)) {
			AdvanceTime (1);
			elapsedTime = 0f;
		}
	}

//	void OnGUI() {
//		string date_text = date.ToString ("F");
//		GUI.Label (new Rect (32, 32, 256, 32), date_text);
//	}


}
