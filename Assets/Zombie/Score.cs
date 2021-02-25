using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    private static Score _instance;
    public static Score Instance { get { return _instance; } }

    private TextMeshProUGUI scoreLabel;
    private int scoreCount = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        scoreLabel = GetComponent<TextMeshProUGUI>();
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreLabel.text = scoreCount.ToString();
    }

    public void AddScore(int points)
    {
        scoreCount += points;
        UpdateScore();
    }

    public void SubtractScore(int points)
    {
        scoreCount -= points;
        UpdateScore();
    }
}
