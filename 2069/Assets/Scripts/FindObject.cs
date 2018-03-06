using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{
    public static GameObject FindNearestAliveHost(Vector3 position)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Host");
        GameObject nearestObject = null;
        float nearestObjectDistance = 0;
        foreach (GameObject gameObject in gameObjects)
        {
            float objectDistance = (position - gameObject.transform.position).magnitude;
            if ((objectDistance < nearestObjectDistance || nearestObject == null) && !gameObject.GetComponent<Host>().isDead)
            {
                nearestObject = gameObject;
                nearestObjectDistance = objectDistance;
            }
        }
        return nearestObject;
    }

    public static GameObject FindNearestYellingHost(Vector3 position)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Host");
        GameObject nearestObject = null;
        float closestHostDistance = 0;
        foreach (GameObject gameObject in gameObjects)
        {
            float objectDistance = (position - gameObject.transform.position).magnitude;
            if ((objectDistance < closestHostDistance || nearestObject == null) && gameObject.GetComponent<Host>().isYelling && objectDistance < gameObject.GetComponent<Host>().yellRadius)
            {
                nearestObject = gameObject;
                closestHostDistance = objectDistance;
            }
        }
        return nearestObject;
    }

    public static GameObject FindNearestAliveMIB(Vector3 position)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("MIB");
        GameObject nearestObject = null;
        float nearestObjectDistance = 0;
        foreach (GameObject gameObject in gameObjects)
        {
            float objectDistance = (position - gameObject.transform.position).magnitude;
            if ((objectDistance < nearestObjectDistance || nearestObject == null) && !gameObject.GetComponent<MIB>().isDead)
            {
                nearestObject = gameObject;
                nearestObjectDistance = objectDistance;
            }
        }
        return nearestObject;
    }
}
