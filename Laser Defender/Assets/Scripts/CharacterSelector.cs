using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {

	private GameObject[] shipToggle;
	public GameObject[] selectedShipMarks; // Find another way to reference this
	public GameObject[] playerShips;
	public static GameObject selectedShip;

	void Start ()
	{	
		shipToggle = GameObject.FindGameObjectsWithTag ("Toggle");
		SetDefaultShip();
	}

	void Update ()
	{
		SelectedShip();
	}

	void SetDefaultShip ()
	{
		for (int i = 0; i < shipToggle.Length; i++) {
			if (shipToggle[i].name == "Default"){
				shipToggle[i].GetComponent<Toggle>().isOn = true;
			}
		}
	}

	void SelectedShip ()
	{
		for (int i = 0; i < shipToggle.Length; i++) 
		{
			if (shipToggle [i].GetComponent<Toggle>().isOn == true) 
			{
				selectedShip = playerShips [i];
				selectedShipMarks [i].GetComponent<Image>().enabled = true;
			} 
			else 
			{
				selectedShipMarks [i].GetComponent<Image>().enabled = false;

			}
		}
	}
}