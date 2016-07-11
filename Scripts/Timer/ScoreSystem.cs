using UnityEngine;
using System.Collections;
using System;

public class ScoreSystem : MonoBehaviour
{
    public string levelKey;
    public int leaderboardSize;

    private int currentScore;
    private int[] bestScores;
    private int bestScore;
    private string bestScoreKey;

    public bool bestScoreHigh;

    // Starts the timer and reads current best times
    void Start()
    {
        if(bestScoreHigh)
            bestScore = 0;
        else
            bestScore = int.MaxValue;

        bestScores = new int[leaderboardSize];

        for(int i = 0; i < bestScores.Length; i++)
        {
            bestScoreKey = levelKey + (i + 1).ToString();
            bestScores[i] = PlayerPrefs.GetInt(bestScoreKey, 0);
        }
    }

    // Saves the time to player prefs
    public void SaveScore(int score)
    {
        SetCurrentScore(score);
        if(bestScoreHigh)
            SaveScoreHighest();
        else
            SaveScoreLowest();
    }

    private void SaveScoreLowest()
    {
        for(int i = 0; i < bestScores.Length; i++)
        {
            bestScoreKey = bestScores + (i + 1).ToString();
            bestScore = PlayerPrefs.GetInt(bestScoreKey, 0);

            if(currentScore < bestScore)
            {
                PlayerPrefs.SetInt(bestScoreKey, currentScore);
                currentScore = bestScore;
            }
        }
        PlayerPrefs.Save();
    }

    private void SaveScoreHighest()
    {
        for(int i = 0; i < bestScores.Length; i++)
        {
            bestScoreKey = bestScores + (i + 1).ToString();
            bestScore = PlayerPrefs.GetInt(bestScoreKey, 0);

            if(currentScore > bestScore)
            {
                PlayerPrefs.SetInt(bestScoreKey, currentScore);
                currentScore = bestScore;
            }

            if(bestScore == 0)
            {
                PlayerPrefs.SetInt(bestScoreKey, currentScore);
                i = bestScores.Length;
            }
        }
        PlayerPrefs.Save();
    }

    // Returns the current time taken
    public int GetCurrentScore()
    {
        return currentScore;
    }

    // Returns the current time taken
    public void SetCurrentScore(int newScore)
    {
        currentScore = newScore;
    }
}