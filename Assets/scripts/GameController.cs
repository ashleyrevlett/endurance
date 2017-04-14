using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

	GameObject player;
	Actor playerActor;

	public GameObject crewMemberPrefab;

	[Range(1, 50)]
	[SerializeField]
	public int totalCrew = 10;

	List<Actor> crewMembers = new List<Actor>();

	NameGenerator namer = new NameGenerator();

	Clock gameClock;
	//	List<Ship> ships;
	//	Board board;
	//  storyevents


	void Start () {
		gameClock = gameObject.GetComponent<Clock> ();
		player = GameObject.FindGameObjectWithTag ("Player");	
		playerActor = player.GetComponent<Actor> ();

		for (int i = 0; i < totalCrew; i++) {
			GameObject crew = Instantiate(crewMemberPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			Actor actor = crew.GetComponent<Actor> ();
			actor.randomize (namer);
			crewMembers.Add (actor);
		};

		printState ();
	}


	void printState() {

		string msg;

		msg = gameClock.getDate ().ToShortDateString ();

		msg += string.Format ("\n{0}\t\tSpirit: {1}\tEnd. {2}\t Skill {3}", playerActor.getFullName (), playerActor.spirit, playerActor.endurance, playerActor.skill);

		for (int i=0; i < crewMembers.Count; i++) {
			Actor crew = crewMembers [i];
			msg = string.Format ("{4}\n{0}\t\tSpirit: {1}\tEnd. {2}\t Skill {3}", crew.getFullName (), crew.spirit, crew.endurance, crew.skill, msg);
		}

		Debug.Log (msg);

	}
}
