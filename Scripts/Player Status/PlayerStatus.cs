using UnityEngine;
using System.Collections;
using System;

public class PlayerStatus : MonoBehaviour
{
    public int ammoCount;
    public string[] targetTags;

    private int numOfTargets = 0;
    private int currentStreak = 0;
    private int minimumStreakRequired = 3;

    public GameObject timerGameObject;
    private SceneTimer sceneTimer;

    public bool infiniteAmmo;

    public GameObject displayPlayerTimeGameObject;
    private DisplayPlayerTime displayPlayerTime;

    public GameObject menuPositionControllerObj;
    private MenuPositionController menuPositionController;

    private void Start()
    {
        sceneTimer = (SceneTimer)timerGameObject.GetComponent("SceneTimer");
        displayPlayerTime = (DisplayPlayerTime)displayPlayerTimeGameObject.GetComponent("DisplayPlayerTime");
        menuPositionController = (MenuPositionController)menuPositionControllerObj.GetComponent("MenuPositionController");

        for(int i = 0; i < targetTags.Length; i++)
        {
            numOfTargets += GameObject.FindGameObjectsWithTag(targetTags[i]).Length;
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
        currentStreak++;
        numOfTargets--;

        if(numOfTargets <= 0)
        {
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
        // Need formula for adding score
        sceneTimer.SetCurrentTime(sceneTimer.GetCurrentTime() - calculateBonus());
    }

    private void DisplayResults()
    {
        sceneTimer.SaveTime();
        displayPlayerTime.DisplayTime(sceneTimer.GetCurrentTime());
        menuPositionController.ShowMenu();
    }

    private int calculateBonus()
    {
        if(currentStreak > minimumStreakRequired)
        {
            double bonus = Math.Pow(2, (currentStreak - 1));
            return (int)bonus;
        }
        else
            return 0;
    }
}
