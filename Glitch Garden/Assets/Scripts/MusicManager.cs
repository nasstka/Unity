using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	public AudioClip[] levelMusicChangeArray;

	private AudioSource music;

	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
	}

	void Start ()
	{
		music = GetComponent<AudioSource> ();
		music.volume = PlayerPrefsManager.GetMasterVolume ();
	}

	void OnEnable ()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		int sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		AudioClip thisLevelMusic = levelMusicChangeArray [sceneIndex];

		if (thisLevelMusic) {
			music.clip = thisLevelMusic;
			music.loop = true;
			music.Play ();
		}

	}

	public void SetVolume (float volume)
	{
		music.volume = volume;
	}
}
