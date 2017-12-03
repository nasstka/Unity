using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameCilp;
	public AudioClip endClip;
	public AudioClip optClip;

	private AudioSource music;

	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
		
	}

	void OnEnable (){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		music = GetComponent<AudioSource>();
		music.Stop ();

		if (scene.name == "Start Menu") {
			music.clip = startClip;
		}
		if (scene.name == "Game") {
			music.clip = gameCilp;
		}
		if (scene.name == "Win Screen") {
			music.clip = endClip;
		}
		if (scene.name == "Options Menu") {
			music.clip = optClip;
		}
		music.loop = true;
		music.Play();
	}
}
