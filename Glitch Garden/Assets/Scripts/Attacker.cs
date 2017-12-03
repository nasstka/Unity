using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
	[Tooltip ("Average number of seconds between appearance")]
	public float seenEverySeconds;

	private Animator anim;
	private GameObject currentTarget;
	private float currentSpeed;

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	void Update ()
	{
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);	

		if (!currentTarget) {
			anim.SetBool ("isAttacking", false);
		}
	}

	public void SetSpeed (float speed)
	{
		currentSpeed = speed;
	}

	public void Attack (GameObject obj)
	{
		currentTarget = obj;
	}

	// Called from the animator at time of actual blow
	public void StrikeCurrentTarget (float damage)
	{
		if (currentTarget) {
			Health defenderHealth = currentTarget.GetComponent<Health> ();

			if (defenderHealth) {
				defenderHealth.DealDamage (damage);
			}
		}
	}
} 