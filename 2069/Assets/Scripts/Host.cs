using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Host : MonoBehaviour
{
    public float drawAttentionDuration;

    public float yellRadius;

    public bool isYelling = false;
    public bool isDead = false;

    GameObject player;
    CustomCharacterController ccc;
    ParticleSystem soundWaves;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        ccc = GetComponent<CustomCharacterController>();
        ccc.followObject = player;
        soundWaves = GetComponentInChildren<ParticleSystem>();
    }

    public void DrawAttention(Vector3 position)
    {
        if (isDead) return;
        StopAllCoroutines();
        StartCoroutine(DrawAttentionCoroutine(position));
    }

    IEnumerator DrawAttentionCoroutine(Vector3 position)
    {
        ccc.followObject = null;
        ccc.destination = position;
        ccc.isRunning = true;

        float mouseClickedTime = Time.time;
        while ((position - transform.position).magnitude > 0.5f && Time.time - mouseClickedTime < 3)
        {
            yield return null;
        }

        ccc.ClearDestination();
        ccc.isRunning = false;
        soundWaves.Play();
        isYelling = true;

        yield return new WaitForSeconds(drawAttentionDuration);

        StopDrawingAttention();
    }

    public void StopDrawingAttention()
    {
        if (isDead) return;
        StopAllCoroutines();
        isYelling = false;
        ccc.followObject = player;
        soundWaves.Stop();
    }

    public void Die()
    {
        isDead = true;
        ccc.SetMovementEnabled(false);
        soundWaves.Stop();
        GameOver.instance.EndGameIfNoHostsRemain();
        StartCoroutine(DieCoroutine());
    }

    IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
