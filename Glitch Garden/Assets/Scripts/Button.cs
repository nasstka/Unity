using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;
	private Text costText;

	void Start ()
	{
		buttonArray = FindObjectsOfType<Button> ();
		GetComponent<SpriteRenderer> ().color = Color.black;

		DisplayDefenderCost ();
	}

	void OnMouseDown ()
	{	
		foreach (Button buttonItem in buttonArray) {
			buttonItem.GetComponent<SpriteRenderer> ().color = Color.black;
		}

		GetComponent<SpriteRenderer> ().color = Color.white;

		selectedDefender = defenderPrefab;
	}

	void DisplayDefenderCost ()
	{
		costText = GetComponentInChildren<Text> ();
		string defenderCost = defenderPrefab.GetComponent<Defender> ().starCost.ToString ();
		if (costText) {
			costText.text = defenderCost;
		} else {
			Debug.LogWarning ("Missing Text component!!");
		} 
	}
}
