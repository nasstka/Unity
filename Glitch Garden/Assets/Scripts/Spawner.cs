using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] attackerPrefab;

	void Update ()
	{	

		foreach (GameObject thisAttacker in attackerPrefab) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	void Spawn (GameObject myGameObject)
	{	
		Instantiate (myGameObject, transform.position, Quaternion.identity, transform);
	}

	bool isTimeToSpawn (GameObject attackerGameObject)
	{	
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();

		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}

		float threshold = spawnPerSecond * Time.deltaTime / 5;

		return Random.value < threshold;
	}
}
