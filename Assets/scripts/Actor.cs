using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	public enum ActorStatus {OnShip, OnLand, InWater, Dead};

	public string firstName;
	public string lastName;
	public ActorStatus status = ActorStatus.OnShip;

	private Ship actorShip;

	[Range(0, 100)]
	public int morale = 100;

	[Range(0, 100)]
	public int health = 100;

	[Range(0, 100)]
	public int experience = 100;

	[Range(0, 100)]
	public int spirit = 100;

	[Range(0, 100)]
	public int endurance = 100;

	[Range(0, 100)]
	public int skill = 100;


	void Start () {
		randomize ();
	}

	void Update () {
	}

	public void setShip(Ship theShip) {
		actorShip = theShip;
	}
		
	public Ship getShip() {
		return actorShip;
	}

	public void randomize() {
		// #TODO change random to bell curve distribution
		spirit = Random.Range(0, 100);
		endurance = Random.Range(0, 100);
		skill = Random.Range(0, 100);
	}
		
	public void setName(NameGenerator namer) {
		string[] randomName = namer.randomFullName ();
		firstName = randomName [0];
		lastName = randomName [1];
	}

	public string getFullName() {
		return string.Format ("{0} {1}", firstName, lastName);
	}


}
