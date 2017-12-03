using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	void OnDrawGizmos (){
		Gizmos.DrawWireSphere(transform.position, 1f);
	}

	// Use this for initialization
	void Start () {
		Instantiate(CharacterSelector.selectedShip, transform.position, Quaternion.identity);
	}
}
