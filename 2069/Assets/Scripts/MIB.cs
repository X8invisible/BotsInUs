using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIB : MonoBehaviour
{

    public float killRadius;

    public bool isKilling = false;
    public bool isDead = false;

    CustomCharacterController ccc;
    Light taserLight;

    void Start()
    {
        ccc = GetComponent<CustomCharacterController>();
        taserLight = GetComponentInChildren<Light>();
    }

    void Update()
    {
        if (isKilling) return;

        if (GameOver.instance.gameOver)
        {
            ccc.ClearDestination();
            return;
        }

        GameObject nearestYellingHost = FindObject.FindNearestYellingHost(transform.position);
        if (nearestYellingHost != null)
        {
            ccc.followObject = nearestYellingHost;
            ccc.isRunning = true;
            TryKilling(nearestYellingHost);
            return;
        }

        GameObject nearestHost = FindObject.FindNearestAliveHost(transform.position);
        if (nearestHost!= null)
        {
            ccc.followObject = nearestHost;
            ccc.isRunning = false;
            TryKilling(nearestHost);
            return;
        }
    }

    void TryKilling(GameObject targetHost)
    {
        if ((targetHost.transform.position - transform.position).magnitude < 1.1)
        {
            targetHost.GetComponent<Host>().Die();
            StartCoroutine(Kill());
        }
    }

    IEnumerator Kill()
    {
        ccc.SetMovementEnabled(false);
        isKilling = true;
        StartCoroutine(TaserFlash());
        yield return new WaitForSeconds(1);
        isKilling = false;
        ccc.SetMovementEnabled(true);
    }

    IEnumerator TaserFlash()
    {
        for (int i = 0; i<8; i++)
        {
            taserLight.enabled = true;
            yield return new WaitForSeconds(0.03f);
            taserLight.enabled = false;
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void Die()
    {
        StartCoroutine(DieCoroutine());
    }

    IEnumerator DieCoroutine()
    {
        isDead = true;
        ccc.SetMovementEnabled(false);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
