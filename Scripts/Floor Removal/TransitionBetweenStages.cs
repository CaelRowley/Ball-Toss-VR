using UnityEngine;
using System.Collections;

public class TransitionBetweenStages : MonoBehaviour {
    public int stage = 1;

    void Start()
    {
        ToggleObjectVisiblity.ToggleObjectVisible("Stage 3", false);
    }

    public void Transition(){
        if(stage == 1)
        {
            ToggleObjectVisiblity.ToggleObjectVisible("Stage " + stage, false);
            ToggleObjectVisiblity.ToggleObjectVisible("Roof Stage " + (stage + 1), false);
            ToggleObjectVisiblity.ToggleObjectVisible("Stage 3", true);
            stage++;
        }
        else if(stage == 2)
        {
            ToggleObjectVisiblity.ToggleObjectVisible("Stage " + stage, false);
            ToggleObjectVisiblity.ToggleObjectVisible("Roof Stage " + (stage + 1), false);
            stage++;
        }                    
    }

    public int checkStage()
    {
        return stage;
    }
}
