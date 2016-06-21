using UnityEngine;
using System.Collections;
using System;

public class PlayerStatus : MonoBehaviour
{
    public int ammoCount;
    public string[] targetTags;

    private int numOfTargets = 0;
    private int currentStreak = 0;
    private int tempAmmoCount = 0;

    public GameObject timerGameObject;
    private SceneTimer sceneTimer;

    private void Start()
    {
        sceneTimer = (SceneTimer)timerGameObject.GetComponent("SceneTimer");

        for(int i = 0; i < targetTags.Length; i++)
        {
            numOfTargets += GameObject.FindGameObjectsWithTag(targetTags[i]).Length;
        }

        Debug.Log("num of targets: " + numOfTargets);
    }


    public bool HasAmmo()
    {
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
        currentStreak++;
        numOfTargets--;

        if(numOfTargets <= 0)
        {
            if(currentStreak >= 3)
                AddStreakScore();

            DisplayResults();
        }
    }

    public void TargetMiss()
    {
        if(numOfTargets > 0)
            AddStreakScore();

        currentStreak = 0;
    }

    private void AddStreakScore()
    {
        sceneTimer.SetCurrentTime(sceneTimer.GetCurrentTime() - (currentStreak));
    }

    private void DisplayResults()
    {
        sceneTimer.SaveTime();
    }
}
