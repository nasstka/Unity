using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizards : MonoBehaviour {

	int max;
	int min;
	int guess;

	public int maxGuesses = 5;

	public Text guessText;


	// Use this for initialization
	void Start () 
	{
		StartGame();
	}

	public void GuessHigher () {
		min = guess;
		NextGuess();
	}

	public void GuessLower () {
		max = guess;
		NextGuess();
	}

	void StartGame ()
	{
		max = 1000;
		min = 1;
		NextGuess();

		max += 1;
	}
	
	void NextGuess ()
	{
		guess = UnityEngine.Random.Range(min, max + 1);
		maxGuesses -= 1;
		guessText.text = guess.ToString();

		if (maxGuesses <= 0) {
			SceneManager.LoadScene("Win");
		}
	}
}
