using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
	private Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		ChangeStoneState (collider, true);
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		ChangeStoneState (collider, false);
	}

	void ChangeStoneState (Collider2D collider, bool isUnderAttack)
	{
		Attacker attacker = collider.GetComponent<Attacker> ();
		if (attacker) {
			animator.SetBool ("isUnderAttack", isUnderAttack);
		}
	}
	// ALTERNATIVE Doesn't work
	//	void OnTriggerStay2D (Collider2D collider)
	//	{
	//		Attacker attacker = collider.GetComponent<Attacker> ();
	//		if (attacker) {
	//			animator.SetTrigger ("UnderAttack");
	//		}
	//	}
}
