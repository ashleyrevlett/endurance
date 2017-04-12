using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator
{

	List<string> firstNames;
	List<string> lastNames;

	private string[] loadData (string filePath) {
		string fileData = System.IO.File.ReadAllText (filePath);
		string[] lines = fileData.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
		return lines;
	}

	public NameGenerator () {

		firstNames = new List<string> (loadData ("Assets/data/names-first.csv"));
		lastNames = new List<string> (loadData ("Assets/data/names-last.csv"));

		Debug.Log("firstNames: " + firstNames.Count);
		Debug.Log("lastNames: " + lastNames.Count);

	}

	public string[] randomFullName() {
		string firstName = randomName(firstNames);
		string lastName = randomName(lastNames);
		return new string[] { firstName, lastName };
	}
		
	string randomName(List<string> namesList) {
		int index = UnityEngine.Random.Range(0, namesList.Count);
		return namesList [index];
	}

}
