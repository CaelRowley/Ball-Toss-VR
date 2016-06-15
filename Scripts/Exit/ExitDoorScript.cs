using UnityEngine;
using System.Collections;

public class ExitDoorScript : MonoBehaviour {

    private void onCollisionEnter(Collision colllider)
    {
        Debug.Log("Collision");
        //Application.Quit();
    }
}
