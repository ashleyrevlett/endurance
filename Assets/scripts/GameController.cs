using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

	public GameObject crewMemberPrefab;
	public GameObject shipPrefab;

	[Range(1, 50)]
	public int totalCrew = 10;

	NameGenerator namer = new NameGenerator();

	Actor playerActor;
	List<Actor> crewMembers = new List<Actor>();
	Clock gameClock;

	private int totalShips = 4;
	List<Ship> ships = new List<Ship>();
	Ship mainShip;

	GUIStyle style = new GUIStyle();
	public Font guiFont;
	//	Board board;
	//  storyevents


	void Start () {
		
		// Position the Text in the center of the Box
		style.alignment = TextAnchor.UpperLeft;
		style.normal.textColor = Color.black;
		style.font = guiFont;
		style.fontSize = 10;

		gameClock = gameObject.GetComponent<Clock> ();
		GameObject player = GameObject.FindGameObjectWithTag ("Player");	
		playerActor = player.GetComponent<Actor> ();

		// create ships
		initShips ();

		// create crew, assign to ships
		initCrew ();

	
	}


	void initShips() {
		string[] shipNames = { "Endurance", "James Caird", "Stancomb Wills", "Dudley Docker" };
		int[] shipCapacities = { 50, 8, 8, 8 };
			
		for (int i = 0; i < totalShips; i++) {
			GameObject obj = Instantiate(shipPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			Ship ship = obj.GetComponent<Ship> ();
			ship.createShip (shipNames [i], shipCapacities [i]);
			ships.Add (ship);

			// remember which one is the endurance
			if (i == 0) {
				mainShip = ship;
			}
		}
	}


	void initCrew() {
		// create crew
		for (int i = 0; i < totalCrew; i++) {
			GameObject crew = Instantiate(crewMemberPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			Actor actor = crew.GetComponent<Actor> ();
			actor.setName (namer);
			actor.setShip (mainShip);
			crewMembers.Add (actor);
		};

		// set player to be member of mainship too
		playerActor.setShip(mainShip);
	
	}



	string getState() {

		string msg;

		// print time
		msg = gameClock.getDate ().ToString ();
		msg += "\n\n";

		// print player
		msg += string.Format ("{0}   SPR {1}\tEND {2}\t SKL {3}\t{4}", playerActor.getFullName (), playerActor.spirit, playerActor.endurance, playerActor.skill, playerActor.getShip());

		// print crew
		for (int i=0; i < crewMembers.Count; i++) {
			Actor crew = crewMembers [i];
			string crewShortName = crew.getFullName ().Substring (0, Mathf.Min(crew.getFullName ().Length, 15));
			msg = string.Format ("{5}\n{0}\t    SPR {1}\tEND {2}\t SKL {3}\t{4}", crewShortName, crew.spirit, crew.endurance, crew.skill, crew.getShip(), msg);
		}

		msg += "\n\n";

		// print ships
		for (int i=0; i < ships.Count; i++) {
			Ship ship = ships [i];
			msg = string.Format ("{3}\n{0}\t\tHealth: {1}\tCapacity: {2}", ship.name, ship.health, ship.getCapacity(), msg);
		}

		msg += "\n\n";

		return msg;

	}


	void OnGUI () {
		
		// Make a background box
		GUI.Box(new Rect(10,10,Screen.width-20, Screen.height-20), getState(), style);

//
//		// Make the second button.
//		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
//			Application.LoadLevel(2);
//		}
	}


}
