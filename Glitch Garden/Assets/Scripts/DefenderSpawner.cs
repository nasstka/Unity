using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
	private GameObject defendersParent;
	private StarDisplay starDisplay;

	void Start ()
	{
		CreateParentGameObject ();
		starDisplay = FindObjectOfType<StarDisplay> ();
	}

	void OnMouseDown ()
	{
		Vector2 rawPosition = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPosition = SnapToGrid (rawPosition);
		GameObject defender = Button.selectedDefender;

		int defenderCost = defender.GetComponent<Defender> ().starCost;
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			Instantiate (defender, roundedPosition, Quaternion.identity, defendersParent.transform);
		} else {
			Debug.Log ("Insufficient stars to spawn");
		}
	}

	Vector2 SnapToGrid (Vector2 rawWorldPosition)
	{
		Vector2 roundedWorldPosition = Vector2Int.RoundToInt (rawWorldPosition);

		return roundedWorldPosition;

		// ALTERNATIVE
		// float newX = Mathf.RoundToInt (rawWorldPosition.x);
		// float newY = Mathf.RoundToInt (rawWorldPosition.y);
		// return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick ()
	{	
		Camera camera = Camera.main;

		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = camera.nearClipPlane;

		Vector2 worldPosition = camera.ScreenToWorldPoint (new Vector3 (mouseX, mouseY, distanceFromCamera));

		return worldPosition;
	}

	void CreateParentGameObject ()
	{
		defendersParent = GameObject.Find ("Defenders");

		if (!defendersParent) {
			defendersParent = new GameObject ("Defenders");
		}
	}
}
