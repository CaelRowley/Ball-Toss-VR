using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitDoorScript : MonoBehaviour {

    private void OnCollisionEnter(Collision colllider)
    {
        Debug.Log("Exit Collision");
        //Application.Quit();
        //SceneManager.LoadScene("Level 1 Office");
    }
}
