using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class StartGameButton : Button
{
    public string sceneName;

    public override void activate()
    {
        SceneManager.LoadScene(sceneName);
    }

}
