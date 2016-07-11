using UnityEngine;
using System.Collections;

public class DisplayPlayerScore : MonoBehaviour
{
    public GameObject button;

    public void DisplayScore(int score)
    {
        TextMesh textMesh = (TextMesh)button.GetComponent("TextMesh");
        textMesh.text = "Score: " + score;
    }
}
