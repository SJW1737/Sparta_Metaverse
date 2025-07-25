using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlappyResultDisplay : MonoBehaviour
{
    public TMP_Text resultText;

    void Start()
    {
        int score = GameResult.lastFlappyScore;
        int best = GameResult.bestFlappyScore;

        if (score >= 0)
        {
            resultText.text = $"Score: {score} (Best: {best})";
            resultText.gameObject.SetActive(true);
            StartCoroutine(HideResultTextAfterSeconds(3f));

            GameResult.lastFlappyScore = -1;
        }
    }

    IEnumerator HideResultTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        resultText.gameObject.SetActive(false);
    }
}
