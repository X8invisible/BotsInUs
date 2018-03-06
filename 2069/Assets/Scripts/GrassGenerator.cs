using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour {

    public float grassRegionWidth;
    public GameObject[] grassObjectPrefabs;
    public int grassObjectCount;

	// Use this for initialization
	void Start () {
        GenerateGrass();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenerateGrass()
    {
        for(int i = 0; i<grassObjectCount; i++)
        {
            GameObject selectedPrefab = grassObjectPrefabs[Random.Range(0, grassObjectPrefabs.Length)];
            Vector3 selectedPosition = new Vector3(Random.Range(-grassRegionWidth / 2, grassRegionWidth / 2), 0, Random.Range(-grassRegionWidth / 2, grassRegionWidth / 2));
            Instantiate(selectedPrefab, selectedPosition, Quaternion.identity);
        }
    }
}
