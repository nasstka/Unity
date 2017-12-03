using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
	public float speed, damage;

	void Update ()
	{
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Attacker attacker = collider.GetComponent<Attacker> ();

		if (attacker) {
			Health health = attacker.GetComponent<Health> ();
			health.DealDamage (damage);
			Destroy (gameObject);
		}
	}
}
