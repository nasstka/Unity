using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
	public Vector3 launchVelocity;
	public bool inPlay = false;

	private AudioSource audioSource;
	private Rigidbody rigidBody;
	private Vector3 startBallPosition;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.useGravity = false;

		startBallPosition = transform.position;
	}

	public void Launch (Vector3 velocity)
	{	
		inPlay = true;

		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource = GetComponent<AudioSource> ();
		audioSource.Play ();
	}

	public void Reset ()
	{	
		inPlay = false;

		transform.position = startBallPosition;
		transform.rotation = Quaternion.identity;

		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
	}
}
