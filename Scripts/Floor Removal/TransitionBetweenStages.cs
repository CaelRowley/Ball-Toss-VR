using UnityEngine;
using System.Collections;

public class TransitionBetweenStages : MonoBehaviour {
    //public int stage = 1;
    public bool level1 = true;
    public bool level2 = false;
    //private GameObject stage3;

    public void Transition(){
        
        if(level1)
        {
            ToggleObjectVisiblity.ToggleObjectVisible("Stage 1 Floor", false);
            ToggleObjectVisiblity.ToggleObjectVisible("Roof Stage 2", false);
            //stage3 = GameObject.Find("Stage 3");
            //stage3.SetActive(false);
            level1 = false;
            
        }

        if(level2)
        {
            ToggleObjectVisiblity.ToggleObjectVisible("Stage 2 Floor", false);
            ToggleObjectVisiblity.ToggleObjectVisible("Roof Stage 3", false);
            //stage3.SetActive(true);
            level2 = false;
        }            
    }
}
