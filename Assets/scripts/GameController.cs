using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

	GameObject player;
	public GameObject crewMemberPrefab;

	[Range(1, 100)]
	[SerializeField]
	public int totalCrew = 10;

	List<Actor> crewMembers = new List<Actor>();

	NameGenerator namer = new NameGenerator();

//	List<Ship> ships;
//	Board board;
	// storyevents


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");	

		for (int i = 0; i < totalCrew; i++) {
			GameObject crew = Instantiate(crewMemberPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			Actor actor = crew.GetComponent<Actor> ();
			actor.randomize (namer);
			crewMembers.Add (actor);
		};

		printState ();
	}

	void printState() {
	
		foreach (Actor crew in crewMembers) {
			string msg = string.Format ("{0}\tSpirit: {1}\tEnd. {2}\t Skill {3}", crew.getFullName (), crew.spirit, crew.endurance, crew.skill);
			Debug.Log (msg);
		}

	}
}
