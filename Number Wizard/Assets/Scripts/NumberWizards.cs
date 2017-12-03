using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizards : MonoBehaviour {

	int max;
	int min;
	int guess;

	// Use this for initialization
	void Start () 
	{
		StartGame();
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			guess = (max + min) / 2;
			NextGuess();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			max = guess;
			guess = (min + max) / 2;
			NextGuess();
		}
		else if (Input.GetKeyDown(KeyCode.Return)) {
			print("I won!");
			StartGame();
		}



	}

	void StartGame ()
	{
		max = 1000;
		min = 1;
		guess = 500;

		print("==============================================");
		print("Welcone to Number Wizard");
		print("Pick a number in your head, but don't tell me!");
		
		print("The highest number you can pick is " + max);
		print("The lowest number you can pick is " + min);
		
		print(String.Format("Is the number higher or lower than {0}?", guess));
		print("Up arrow = higher, down arrow = lower, return = equal");

		max += 1;
	}
	
	void NextGuess ()
	{
		print(String.Format("Higher or lower than {0}?", guess));
		print("Up arrow = higher, down arrow = lower, return = equal");
	}
}
