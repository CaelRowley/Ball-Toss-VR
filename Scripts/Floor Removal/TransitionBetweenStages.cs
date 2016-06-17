﻿using UnityEngine;
using System.Collections;

public class TransitionBetweenStages : MonoBehaviour {
    //public int stage = 1;
    public bool level1 = false;
    public bool level2 = false;



    public void Transition(){
        if(level1)
        {
            ToggleObjectVisiblity.ToggleObjectVisible("Stage 1", false);
            ToggleObjectVisiblity.ToggleObjectVisible("Roof Stage 2", false);
            level1 = false;
            ToggleObjectVisiblity.ToggleObjectVisible("Stage 3", true);
        }
        else if(level2)
        {
            ToggleObjectVisiblity.ToggleObjectVisible("Stage 2", false);
            ToggleObjectVisiblity.ToggleObjectVisible("Roof Stage 3", false);
            level2 = false;
        }            
    }
}