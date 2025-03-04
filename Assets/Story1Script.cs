﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Story1Script : MonoBehaviour {

	// Door
	GameObject door;
	// Door script
	BeginDoorScript doorScript;
	// Is input enabled?
	bool inputEnabled = false;

	// Use this for initialization
	void Start () {
		door = GameObject.Find("Door");
		doorScript = door.GetComponent<BeginDoorScript>();
		// Start the unlock coortutine
		StartCoroutine(EnableInputDelayed());
		StartCoroutine(LoadNextDeleyed());
	}

	void Update()
	{
		if (Input.anyKeyDown && inputEnabled)  {
			inputEnabled = false;
			StartCoroutine (LoadNext ());
		}
	}

	IEnumerator LoadNext()
	{
		yield return new WaitForSeconds (doorScript.SetOpen (false));
		SceneManager.LoadScene ("Story2");
	}

	IEnumerator LoadNextDeleyed()
	{
		yield return new WaitForSeconds (9f);
		if (inputEnabled) {
			inputEnabled = false;
			yield return new WaitForSeconds (doorScript.SetOpen (false));
			SceneManager.LoadScene ("Story2");
		}
	}

	IEnumerator EnableInputDelayed() {
		yield return new WaitForSeconds (doorScript.GetOpeningTime ());
		inputEnabled = true;
	}

}