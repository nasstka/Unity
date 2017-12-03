using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public GameObject projectile, gun;

	private Animator animator;
	private GameObject projectileParent;
	private Spawner myLaneSpawner;


	void Start ()
	{	
		animator = GetComponent<Animator> ();

		CreateParentGameObject ();
		SetMyLaneSpawner ();
	}

	void Update ()
	{
		if (isAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	void SetMyLaneSpawner ()
	{	
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			float yLanePosition = spawner.transform.position.y;
			if (yLanePosition == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + "can't find spawner in lane");
	}

	bool isAttackerAheadInLane ()
	{
		// Exit if no attackers in lane
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		// If there are attackers, are they ahead? (looping over child objects)
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		// Attacker in lane, but behind us.
		return false;
	}

	private void Fire ()
	{	
		Vector3 gunPosition = gun.transform.position;
		Instantiate (projectile, gunPosition, Quaternion.identity, projectileParent.transform);		
	}

	void CreateParentGameObject ()
	{
		projectileParent = GameObject.Find ("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}
	}
}
