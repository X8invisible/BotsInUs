using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIBSpawning : MonoBehaviour {

    public GameObject mibPrefab;
    public int intialMIBCount;
    public int currentMaximumMIBCount;
    public int secondsBetweenIncreases;
    GameObject player;

    public float spawnRadius;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update () {
        currentMaximumMIBCount = intialMIBCount + Mathf.FloorToInt(SurvivalTimer.instance.timer / secondsBetweenIncreases);

		if (GetMIBCount()< currentMaximumMIBCount)
        {
            SpawnMIB();
        }
	}

    int GetMIBCount()
    {
        return GameObject.FindGameObjectsWithTag("MIB").Length;
    }

    void SpawnMIB()
    {
        Vector3 spawnPostition = player.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * spawnRadius;
        GameObject newMIB = Instantiate(mibPrefab, spawnPostition, Quaternion.identity);
    }
}
