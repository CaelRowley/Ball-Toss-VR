using UnityEngine;
using System.Collections;
using System;

public class PlayerStatus : MonoBehaviour
{
    public float displayScoreDelay;
    public int ammoCount;
    public string[] targetTags;

    private int numOfTargets = 0;
    private int numOfTargetsHit = 0;
    private int minimumStreakRequired = 3;

    public GameObject timerGameObject;
    private ScoreSystem scoreSystem;

    public bool infiniteAmmo;
    public bool hasTimer;

    public GameObject displayPlayerScoreGameObject;
    private DisplayPlayerScore displayPlayerScore;

    public GameObject menuPositionControllerObj;
    private MenuPositionController menuPositionController;

    private int currentTime = 0;
    private bool isLevelFinished = false;

    private void Start()
    {
        if(hasTimer)
            StartCoroutine("Timer");

        scoreSystem = (ScoreSystem)timerGameObject.GetComponent("ScoreSystem");
        displayPlayerScore = (DisplayPlayerScore)displayPlayerScoreGameObject.GetComponent("DisplayPlayerScore");
        menuPositionController = (MenuPositionController)menuPositionControllerObj.GetComponent("MenuPositionController");

        for(int i = 0; i < targetTags.Length; i++)
        {
            numOfTargets += GameObject.FindGameObjectsWithTag(targetTags[i]).Length;
        }
    }

    private void Update()
    {
        if(isLevelFinished)
        {
            StartCoroutine("DisplayResults");
            isLevelFinished = false;
        }
    }

    public bool HasAmmo()
    {
        if(infiniteAmmo)
            return true;
        else
            return ammoCount > 0 ? true : false;
    }

    public int GetAmmoCount()
    {
        return ammoCount;
    }

    public void SetAmmoCount(int newAmmoCount)
    {
        ammoCount = newAmmoCount;
    }

    public void TargetHit()
    {
        numOfTargetsHit++;
        numOfTargets--;
        if(numOfTargets <= 0)
            isLevelFinished = true;
    }

    public void TargetMiss()
    {
        // If miss
    }

    private IEnumerator DisplayResults()
    {
        if(hasTimer)
            scoreSystem.SaveScore(currentTime);
        else
            scoreSystem.SaveScore(numOfTargetsHit);

        yield return new WaitForSeconds(displayScoreDelay);
        displayPlayerScore.DisplayScore(scoreSystem.GetCurrentScore());
        menuPositionController.ShowMenu();
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

    public void SetNumOfTargets(int newNumOfTargets)
    {
        numOfTargets = newNumOfTargets;
    }
}
