using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour
{
	private Ball ball;
	private Vector3 dragStart, dragEnd, launchVelocity;
	private float startTime, endTime;

	void Start ()
	{
		ball = GetComponent<Ball> ();
	}

	public void DragStart ()
	{
		if (!ball.inPlay) {
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void DragEnd ()
	{	
		if (!ball.inPlay) {
			dragEnd = Input.mousePosition;
			endTime = Time.time;
			
			float dragDuration = endTime - startTime;
			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;
			
			launchVelocity = new Vector3 (launchSpeedX, 0.0f, launchSpeedZ);
			ball.Launch (launchVelocity);
		}

	}

	public void MoveStart (float amount)
	{	
		if (!ball.inPlay) {
			ball.transform.Translate (new Vector3 (amount, 0f, 0f));
			ball.transform.position = new Vector3 (Mathf.Clamp (ball.transform.position.x, -40f, 40f), ball.transform.position.y, ball.transform.position.z);
		}
	}
}
