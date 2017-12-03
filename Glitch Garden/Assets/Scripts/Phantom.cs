using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class Phantom : MonoBehaviour
{
	private Animator anim;
	private Attacker attacker;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		GameObject obj = collider.gameObject;

		// Leave the method if not colliding with defender
		if (!obj.GetComponent<Defender> ()) {
			return;
		}
	
		anim.SetBool ("isAttacking", true);
		attacker.Attack (obj);
	}
}
