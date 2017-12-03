using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
	public Color colorToFadeTo;
	public float fadeTime = 3.0f;

	private Image fadeInPanel;

	void Start ()
	{
		fadeInPanel = GetComponent<Image> ();
	}

	void Update ()
	{
		if (Time.timeSinceLevelLoad < fadeTime) {
			fadeInPanel.CrossFadeColor (colorToFadeTo, fadeTime, true, true);
		} else {
			gameObject.SetActive (false);
		}
	}

}
