using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("game over");
        uiManager.setRestart();

        GameResult.lastFlappyScore = currentScore;
        if (currentScore > GameResult.bestFlappyScore)
            GameResult.bestFlappyScore = currentScore;

        StartCoroutine(GoBackToMap());
    }

    private IEnumerator GoBackToMap()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartGame()
    {
        GameResult.lastFlappyScore = currentScore;

        if (currentScore > GameResult.bestFlappyScore)
            GameResult.bestFlappyScore = currentScore;

        SceneManager.LoadScene("SampleScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
}


