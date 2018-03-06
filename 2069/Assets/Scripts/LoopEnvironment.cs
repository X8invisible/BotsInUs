using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopEnvironment : MonoBehaviour {

    GameObject player;

    public float loopWidth;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject environmentObject in GameObject.FindGameObjectsWithTag("Loop Environment"))
        {
            Vector3 vectorFromPlayer = environmentObject.transform.position - player.transform.position;
            if (vectorFromPlayer.x> loopWidth / 2)
            {
                environmentObject.transform.position += Vector3.left * loopWidth;
            }
            if (vectorFromPlayer.x < -loopWidth / 2)
            {
                environmentObject.transform.position += Vector3.right * loopWidth;
            }
            if (vectorFromPlayer.z > loopWidth / 2)
            {
                environmentObject.transform.position += Vector3.back * loopWidth;
            }
            if (vectorFromPlayer.z < -loopWidth / 2)
            {
                environmentObject.transform.position += Vector3.forward * loopWidth;
            }
        }
	}
}
