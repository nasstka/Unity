using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour
{
    private Ball ball;
    private Vector3 dragStart, dragEnd, launchVelocity;
    private float startTime, endTime;

    void Start()
    {
        ball = GetComponent<Ball>();
    }

    public void DragStart()
    {
        if (!ball.inPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd()
    {	
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;
			
            float dragDuration = endTime - startTime;
            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;
			
            launchVelocity = new Vector3(launchSpeedX, 0.0f, launchSpeedZ);
            ball.Launch(launchVelocity);
        }

    }

    public void MoveStart(float amount)
    {	
        if (!ball.inPlay)
        {
            float xPosition = Mathf.Clamp(ball.transform.position.x + amount, -40f, 40f);
            float yPosition = ball.transform.position.y;
            float zPosition = ball.transform.position.z;
            ball.transform.position = new Vector3(xPosition, yPosition, zPosition);
        }
    }
}
