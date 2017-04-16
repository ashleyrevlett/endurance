using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public int maxHealth = 100;
	public int health = 100;

	int capacity;

//
//	public void setName(string newName) {		
//		shipName = newName;
//	}
//
//

	public int getCapacity() {		
		return capacity;
	}

	public void setCapacity(int newCapacity) {		
		capacity = newCapacity;
	}


	public void createShip(string newName, int newCapacity) {
		name = newName;
		capacity = newCapacity;
	}

}
