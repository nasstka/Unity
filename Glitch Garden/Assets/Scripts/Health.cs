using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public float health;
	public GameObject smoke;

	public void DealDamage (float damage)
	{
		health -= damage;

		if (health < 0f) {
			DestroyObject ();
			SmokePuff ();
		}
	}

	public void DestroyObject ()
	{
		Destroy (gameObject);
		Debug.Log (gameObject + " was destroyed!!");
	}

	void SmokePuff ()
	{
		Instantiate (smoke, transform.position, Quaternion.identity);
	}

}
