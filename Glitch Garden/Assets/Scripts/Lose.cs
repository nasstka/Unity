using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Lose : MonoBehaviour
{
	private LevelManager levelManager;

	void Start ()
	{
		levelManager = FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D ()
	{	
		levelManager.LoadLevel ("03b Lose");
	}
}
