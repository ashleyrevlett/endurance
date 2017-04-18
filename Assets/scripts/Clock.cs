using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

	[Range(1, 5)]
	public int speed = 2;

	DateTime date;
	float elapsedTime = 0f;


	void Start () {
		string iDate = "10/01/1914";	
		date = Convert.ToDateTime(iDate);
	}

	void Update () {
		elapsedTime += Time.deltaTime * speed;
		if (speed == 0f)
			return;
		if (elapsedTime > (10f/(speed*speed))) {
			advanceTime (1, 0);
			elapsedTime = 0f;
		}
	}
		

	public void increaseSpeed() {
		speed = Mathf.Min (speed + 1, 5);
	}


	public void decreaseSpeed() {
		speed = Mathf.Max (speed - 1, 1);
	}


	public DateTime getDate() {
		return date;
	}


	void advanceTime(int hours, int minutes) {
		TimeSpan time = new TimeSpan(hours, minutes, 0);
		date = date.Add(time);
	}


	void OnGUI () {
		GUI.Box(new Rect(150,10,200,20), getDate().ToString());

		if(GUI.Button(new Rect(10, 10, 40, 20), "<<")) {
			decreaseSpeed ();
		}

		GUI.Box(new Rect(55,10,40,20), speed.ToString());

		if(GUI.Button(new Rect(100, 10, 40, 20), ">>")) {
			increaseSpeed ();
		}
	}


}
