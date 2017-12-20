using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public AudioClip callSound;

    private AudioSource audioSource;
    private bool called = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Heli") && !called)
        {  
            called = true;
            Debug.Log("Called");
            audioSource.clip = callSound;
            audioSource.Play();
        }
    }
}
