using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitsSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start ()
	{
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		isBreakable = (this.tag == "Beakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.2f);

		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits () {
		timesHit++;

		int maxHits = hitsSprites.Length + 1;
	
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void PuffSmoke () {
		GameObject smokepuff = Instantiate(smoke, transform.position, Quaternion.identity);
		ParticleSystem ps = smokepuff.GetComponent<ParticleSystem>();
		ParticleSystem.MainModule particle = ps.main;
		particle.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}


	void LoadSprites ()
	{
		int spritesIndex = timesHit - 1;

		if (hitsSprites [spritesIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitsSprites [spritesIndex];
		} else {
			Debug.LogError("Brick sprite is missing");
		}

	}
	// TODO Remove this method once we actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
