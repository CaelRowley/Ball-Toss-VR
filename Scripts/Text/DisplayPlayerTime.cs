using UnityEngine;
using System.Collections;

public class DisplayPlayerTime : MonoBehaviour
{
    public GameObject button;

    public void DisplayTime(int time)
    {
        TextMesh textMesh = (TextMesh)button.GetComponent("TextMesh");
        textMesh.text = "Time: " + time;
    }
}
