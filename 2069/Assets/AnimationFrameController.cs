using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFrameController : MonoBehaviour {

    public Texture[] walkCycle;
    public Texture standTexture;
    int walkCycleCounter;
    public float walkCycleDuration;
    float walkStartTime = 0;
    public float minimumWalkSpeed;

    public GameObject mainTextureObject;
    Renderer rend;

    Vector3 lastPostition;
    float smoothedVelocity;

	// Use this for initialization
	void Start () {
        rend = mainTextureObject.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        Vector3 travelledVector = transform.position - lastPostition;
        float velocity = travelledVector.magnitude / Time.fixedDeltaTime;
        smoothedVelocity = smoothedVelocity * 0.7f + velocity * 0.3f;

        if (smoothedVelocity > minimumWalkSpeed)
        {
            walkCycleCounter = Mathf.FloorToInt((Time.time - walkStartTime) * walkCycle.Length / walkCycleDuration) % 4;
            rend.material.mainTexture = walkCycle[walkCycleCounter];
        }
        else
        {
            rend.material.mainTexture = standTexture;
            walkStartTime = Time.time;
        }

        lastPostition = transform.position;
    }
}
