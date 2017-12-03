using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
	public float spawnDelay = 0.5f;

	private bool movingRight = false;
	private float xmax;
	private float xmin;

	// Use this for initialization
	void Start ()
	{
		SpawnUntilFull();
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distanceToCamera));

		xmax = rightBoundary.x;
		xmin = leftBoundary.x;
	}

	void OnDrawGizmos (){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	// Update is called once per frame
	void Update ()
	{
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);

		if (leftEdgeOfFormation < xmin) {
			movingRight = true;
		} else if (rightEdgeOfFormation > xmax) {
			movingRight = false;
		}

		if (AllMembersDead ()) {
			SpawnUntilFull();
		}
	}

	Transform NextFreePosition (){
		foreach (Transform childPositionGO in transform) {
			if (childPositionGO.childCount == 0) {
				return childPositionGO;
			}
		}
		return null;
	}

	bool AllMembersDead ()
	{
		foreach (Transform childPositionGO in transform) {
			if (childPositionGO.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	void SpawnUntilFull (){
		int enemyPrefabIndex = Random.Range(0,enemyPrefab.Length - 1);
		Transform freePosition = NextFreePosition();
		if(freePosition){
			GameObject enemy = Instantiate (enemyPrefab[enemyPrefabIndex], freePosition.position, Quaternion.identity);
			enemy.transform.parent = freePosition;
		}

		if(NextFreePosition()){
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}
}
