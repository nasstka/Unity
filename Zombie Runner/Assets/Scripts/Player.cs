using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // The parent of spawn points
    public Transform playerSpawnPoints;
    public GameObject landingAreaPrefab;

    private bool reSpawn = false;
    private Transform[] spawnPoints;
    private bool lastRespawnToggle = false;

    void Start()
    {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if (lastRespawnToggle != reSpawn)
        {
            Respawn();
            reSpawn = false;
        }
        else
        {
            lastRespawnToggle = reSpawn;
        }
    }

    private void Respawn()
    {
        int indx = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[indx].transform.position;
    }

    void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
    }

    void DropFlare()
    {
        Vector3 flarePosition = new Vector3(transform.position.x, 50f, transform.position.z);
        Instantiate(landingAreaPrefab, flarePosition, transform.rotation);
    }
}
