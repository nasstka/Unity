using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private Text scoreText;
	public static int score = 0;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>();
		scoreText.text = score.ToString();
	}
	
	public void Score (int points){
		score += points;
		scoreText.text = score.ToString();
	}

	public static void Reset (){
		score = 0;
	}
}
