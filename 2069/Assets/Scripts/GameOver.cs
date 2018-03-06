using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    #region Singleton

    public static GameOver instance = null;
    void Awake()
    {
        instance = this;
    }

    #endregion

    public bool gameOver;
    public GameObject gameOverDialog;
    public Text scoreText;

    public void EndGameIfNoHostsRemain()
    {
        if (FindObject.FindNearestAliveHost(Vector3.zero) == null)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over");
        gameOver = true;
        StartCoroutine(EndGameCoroutine());
    }

    IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(2);
        gameOverDialog.SetActive(true);
        scoreText.text = "You survived " + SurvivalTimer.instance.timer.ToString("F2") + " seconds";

    }
}
