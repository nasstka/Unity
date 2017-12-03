using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour
{
	public enum Status
	{
		SUCCESS,
		FAILURE}

	;

	private Text starText;
	private int startCount = 200;

	void Start ()
	{
		starText = GetComponent<Text> ();
		UpdateDisplay ();
	}

	public void AddStars (int amount)
	{	
		startCount += amount;
		UpdateDisplay ();
	}

	public Status UseStars (int amount)
	{
		if (startCount >= amount) {
			startCount -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	private void UpdateDisplay ()
	{
		starText.text = startCount.ToString ();
	}
}
