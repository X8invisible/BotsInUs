using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameOver.instance.gameOver == false)
        {
            Move();
        }
	}

    void Move()
    {
        Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movementInput = movementInput.normalized;
        gameObject.transform.position += movementInput * playerSpeed * Time.fixedDeltaTime;
    }
}
