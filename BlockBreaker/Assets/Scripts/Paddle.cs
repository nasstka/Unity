using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false; 
	private Ball ball;

	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	void Update ()
	{
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
	}

	void AutoPlay () {
		Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0f);
		// Mouse position in game units
		Vector3 ballPos = ball.transform.position;
		paddlePosition.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
		this.transform.position = paddlePosition;
	}

	void MoveWithMouse () {
		Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0f);
		// Mouse position in game units
		float mousePos = Input.mousePosition.x / Screen.width * 16;
		paddlePosition.x = Mathf.Clamp(mousePos, 0.5f, 15.5f);
		this.transform.position = paddlePosition;

	}
}
