using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // The parent of spawn points
    public Transform playerSpawnPoints;
    public bool reSpawn = false;

    private Transform[] spawnPoints;
    private bool lastToggle = false;

    void Start()
    {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if (lastToggle != reSpawn)
        {
            Respawn();
            reSpawn = false;
        }
        else
        {
            lastToggle = reSpawn;
        }
    }

    private void Respawn()
    {
        int indx = Random.Range(1, spawnPoints.Length);

        transform.position = spawnPoints[indx].transform.position;
    }
}
