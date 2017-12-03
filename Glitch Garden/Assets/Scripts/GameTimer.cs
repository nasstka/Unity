using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public float levelTime = 100;

	private Slider timeSilder;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private bool isEndOfLevel = false;
	private GameObject winLabel;

	void Start ()
	{
		levelManager = FindObjectOfType<LevelManager> ();
		timeSilder = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();

		FindWinLabel ();
		winLabel.SetActive (false);
	}

	void Update ()
	{
		timeSilder.value = Time.timeSinceLevelLoad / levelTime;

		bool timeIsUp = (Time.timeSinceLevelLoad >= levelTime);
		if (timeIsUp && !isEndOfLevel) {
			HandleWinCondition ();
		}
	}

	void FindWinLabel ()
	{
		winLabel = GameObject.Find ("Win");
		if (!winLabel) {
			Debug.LogWarning ("Please create Win object");
		}
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects ();
		audioSource.Play ();
		winLabel.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	void DestroyAllTaggedObjects ()
	{
		GameObject[] taggedGameObjects = GameObject.FindGameObjectsWithTag ("DestroyOnWin");

		foreach (GameObject taggedObject  in taggedGameObjects) {
			Destroy (taggedObject);
		}
	}

	void LoadNextLevel ()
	{
		levelManager.LoadNextLevel ();
	}

}
