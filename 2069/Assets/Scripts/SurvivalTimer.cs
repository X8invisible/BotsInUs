using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalTimer : MonoBehaviour {

    #region Singleton

    public static SurvivalTimer instance = null;
    void Awake()
    {
        instance = this;
    }

    #endregion

    public float timer;

	void Start () {
        timer = 0;
    }
	
	void Update () {
        if (!GameOver.instance.gameOver)
        {
            timer += Time.deltaTime;
        }
    }
}
