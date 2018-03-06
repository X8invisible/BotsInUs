using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaxParticleSize : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<ParticleSystemRenderer>().maxParticleSize = 100;
        GetComponent<ParticleSystem>().Stop();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
