using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlay : MonoBehaviour
{
	private LevelManager levelmanager;

	void Start ()
	{
		levelmanager = FindObjectOfType<LevelManager> ();
	}

	void OnMouseDown ()
	{
		levelmanager.LoadLevel ("01 Start");
	}
}
