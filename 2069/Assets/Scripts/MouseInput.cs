using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    public GameObject cursorObject;

    public LayerMask groundMask;
    Vector3 mousePositionWorldSpace;

	// Use this for initialization
	void Start () {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject closestHost = FindObject.FindNearestAliveHost(mousePositionWorldSpace);

            if (closestHost == null)
            {
                Debug.Log("no host found/all hosts busy");
            }
            else
            {
                closestHost.GetComponent<Host>().DrawAttention(mousePositionWorldSpace);
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject[] hosts = GameObject.FindGameObjectsWithTag("Host");
            foreach (GameObject host in hosts)
            {
                host.GetComponent<Host>().StopDrawingAttention();
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        UpdateMousePosition();

        cursorObject.transform.position = mousePositionWorldSpace;
    }

    void UpdateMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, groundMask))
        {
            mousePositionWorldSpace = hit.point;
        }
    }
}
