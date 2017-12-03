using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
	public float standingThreshold = 10f;
	public float distanceToRaise = 40f;

	private Rigidbody rigidBody;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody> ();
	}

	public bool IsStanding ()
	{
		Vector3 rotation = transform.rotation.eulerAngles;

		float rotationInX = Mathf.Abs (270f - rotation.x);
		float rotationInZ = Mathf.Abs (rotation.z);

		if (rotationInX < standingThreshold && rotationInZ < standingThreshold) {
			return true;
		} else {
			return false;
		}
	}

	public void Raise ()
	{
		if (IsStanding ()) {
			rigidBody.useGravity = false;

			transform.Translate (Vector3.up * distanceToRaise, Space.World);
			transform.rotation = Quaternion.Euler (270f, 0f, 0f);
		}
	}

	public void Lower ()
	{	
		if (IsStanding ()) {
			transform.Translate (Vector3.down * distanceToRaise, Space.World);

			rigidBody.useGravity = true;
		}
	}
}
