using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public AudioClip fireSound;
	public AudioClip deathSound;
	public GameObject[] enemyLaserPrefab;
	public GameObject smoke;
	public float laserSpeed = 10f;
	public float health = 150f;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;

	private ScoreKeeper scoreKeeper;

	void Start (){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	void Update ()
	{
		float probabilty = Time.deltaTime * shotsPerSecond;

		if(Random.value < probabilty){
			Fire();
		}
	}

	void Fire() {
		int laserIndex = Random.Range(0, enemyLaserPrefab.Length - 1);
		GameObject enemyLaser = Instantiate(enemyLaserPrefab[laserIndex], transform.position, Quaternion.identity);
		enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();

		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Die();
			}
		}
	}

	void Die() {
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		Destroy(gameObject);
		scoreKeeper.Score(scoreValue);
		Instantiate(smoke, transform.position, Quaternion.identity);
	}

}
