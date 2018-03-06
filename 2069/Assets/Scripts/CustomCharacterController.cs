using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : MonoBehaviour {

    public float walkSpeed;
    public float runSpeed;
    public bool isRunning;
    float currentSpeed;

    public GameObject followObject;
    public Vector3 destination;
    bool movementEnabled = true;

    Vector3 delayedPosition;
    float initialScaleX;

    Rigidbody rb;

    void Start () {

        rb = GetComponent<Rigidbody>();
        currentSpeed = walkSpeed;
        initialScaleX = transform.localScale.x;
    }

    void FixedUpdate ()
    {
        if (isRunning)
            currentSpeed = runSpeed;
        else
            currentSpeed = walkSpeed;

        rb.velocity = Vector3.zero;

        if (followObject != null)
        {
            destination = followObject.transform.position;
        }

        if (movementEnabled)
        {
            MoveTowardsPosition(destination);
        }

    }

    void MoveTowardsPosition(Vector3 position)
    {
        Vector3 vectorToPosition = position - transform.position;
        Vector3 goalPosition;
        if (vectorToPosition.magnitude < currentSpeed * Time.fixedDeltaTime)
        {
            goalPosition = position;
        }
        else
        {
            goalPosition = transform.position + vectorToPosition.normalized * currentSpeed * Time.fixedDeltaTime;
        }
        rb.MovePosition(goalPosition);

        UpdateFlipped();
    }

    public void SetMovementEnabled(bool enabled)
    {
        movementEnabled = enabled;

        if (enabled)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void ClearDestination()
    {
        followObject = null;
        destination = transform.position;
    }

    void UpdateFlipped()
    {
        Vector3 vectorToDelayedPosition = delayedPosition- transform.position;
        if (vectorToDelayedPosition.magnitude > 0.05f)
        {
            delayedPosition = transform.position + vectorToDelayedPosition.normalized * 0.1f;
        }

        float horizontalMovedDistance = transform.position.x - delayedPosition.x;
        if (Mathf.Abs(horizontalMovedDistance) > 0.02f)
        {
            if (horizontalMovedDistance > 0)
            {
                transform.localScale = new Vector3(initialScaleX, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-initialScaleX, transform.localScale.y, transform.localScale.z);
            }

        }
    }
}
