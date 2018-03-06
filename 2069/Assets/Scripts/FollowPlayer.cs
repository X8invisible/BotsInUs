using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject subject;
    public Vector3 offset;
    public float cameraSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 goalPosition = subject.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, goalPosition, Time.fixedDeltaTime * cameraSpeed);
	}
}
