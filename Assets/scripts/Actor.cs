using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	public enum ActorStatus {OnShip, OnLand, InWater, Dead};

	public string firstName;
	public string lastName;
	public ActorStatus status = ActorStatus.OnShip;

	[Range(0, 100)]
	[SerializeField]
	public int morale = 100;

	[Range(0, 100)]
	[SerializeField]
	public int health = 100;

	[Range(0, 100)]
	[SerializeField]
	public int experience = 100;

	[Range(0, 100)]
	[SerializeField]
	public int spirit = 100;

	[Range(0, 100)]
	[SerializeField]
	public int endurance = 100;

	[Range(0, 100)]
	[SerializeField]
	public int skill = 100;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void randomize(NameGenerator namer) {
		// randomize stat values
		spirit = Random.Range(0, 100);
		endurance = Random.Range(0, 100);
		skill = Random.Range(0, 100);
		string[] randomName = namer.randomFullName ();
		firstName = randomName [0];
		lastName = randomName [1];
	}

	public string getFullName() {
		return string.Format ("{0} {1}", firstName, lastName);
	}

}
