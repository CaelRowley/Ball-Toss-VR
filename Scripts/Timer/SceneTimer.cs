using UnityEngine;
using System.Collections;

public class SceneTimer : MonoBehaviour
{
    public string levelKey;
    public int leaderboardSize;

    private int currentTime;
    private int[] bestTimes;
    private int bestTime;
    private string bestTimeKey;

    // Starts the timer and reads current best times
    void Start()
    {
        StartCoroutine("Timer");
        bestTime = 0;
        bestTimes = new int[leaderboardSize];

        for(int i = 0; i < bestTimes.Length; i++)
        {
            bestTimeKey = levelKey + (i + 1).ToString();
            bestTimes[i] = PlayerPrefs.GetInt(bestTimeKey, 0);
        }
    }

    // Saves the time to player prefs
    public void SaveTime()
    {
        StopCoroutine("Timer");

        for(int i = 0; i < bestTimes.Length; i++)
        {
            bestTimeKey = bestTimes + (i + 1).ToString();
            bestTime = PlayerPrefs.GetInt(bestTimeKey, 0);

            if(currentTime < bestTime)
            {
                PlayerPrefs.SetInt(bestTimeKey, currentTime);
                currentTime = bestTime;
            }

            if(bestTime == 0)
            {
                PlayerPrefs.SetInt(bestTimeKey, currentTime);
                i = bestTimes.Length;
            }
        }
        PlayerPrefs.Save();
    }

    // Adds 1 to currentTime every second
    private IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            currentTime += 1;
        }
    }

    // Returns the current time taken
    public int GetCurrentTime()
    {
        return currentTime;
    }

    // Returns the current time taken
    public void SetCurrentTime(int newCurrentTime)
    {
        currentTime = newCurrentTime;
    }
}