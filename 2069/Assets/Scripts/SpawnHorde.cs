using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHorde : MonoBehaviour {

    public GameObject hostPrefab;
    public int hostCount;
    public float spawnAreaRadius;

	// Use this for initialization
	void Start ()
    {
		for (int i = 0; i<hostCount; i++)
        {
            Vector3 spawnPosition = transform.position + Vector3.right * spawnAreaRadius * Random.Range(1f, -1f) + Vector3.forward * spawnAreaRadius * Random.Range(1f, -1f);
            GameObject newHost = Instantiate(hostPrefab, spawnPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
