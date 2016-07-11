using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class SpherePopUp : PopUp
{
    public override void Activate()
    {
        Debug.Log("SpherePopUp Activate()");
        transform.Translate((Vector3.forward * 2), Space.World);
    }
}
