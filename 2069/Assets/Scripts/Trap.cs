using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    public float trapRadius;

    bool isShut = false;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(-60, 60), 0);
    }

    void Update()
    {
        if (!isShut)
        {
            GameObject nearestHost = FindObject.FindNearestAliveHost(transform.position);
            if (nearestHost != null && (nearestHost.transform.position - transform.position).magnitude < trapRadius)
            {
                nearestHost.GetComponent<Host>().Die();
                SnapShut();
                return;
            }

            GameObject nearestMIB = FindObject.FindNearestAliveMIB(transform.position);
            if (nearestMIB != null && (nearestMIB.transform.position - transform.position).magnitude < trapRadius)
            {
                nearestMIB.GetComponent<MIB>().Die();
                SnapShut();
                return;
            }
        }
    }

    void SnapShut()
    {
        isShut = true;
        //transform.position += Vector3.up;
        GetComponent<Animator>().SetBool("Shut", true);
        StartCoroutine(ReopenCoroutine());
    }

    IEnumerator ReopenCoroutine()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Animator>().SetBool("Shut", false);
        yield return new WaitForSeconds(1f);
        isShut = false;
    }
}
