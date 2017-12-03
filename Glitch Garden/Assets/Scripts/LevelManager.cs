using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public float autoLoadTime;

	void Start ()
	{
		if (autoLoadTime > 0) {
			Debug.Log (String.Format ("Loading next level after: {0} s", autoLoadTime));
			Invoke ("LoadNextLevel", autoLoadTime);
		} else {
			Debug.Log ("Autoloading next level is disabled");
		}
	}

	public void LoadLevel (string name)
	{
		Debug.Log ("New Level loaded: " + name);
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void QuitRequest ()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Debug.Log ("Quit requested");
		Application.Quit ();
		#endif
	}

	// Alternative - Add StartCourutine() on Start
	//	IEnumerator Wait ()
	//	{
	//		yield return new WaitForSeconds(5.0f);
	//
	//		LoadLevel("Start");
	//	}
}
