using UnityEngine;
using System.Collections;

public class ButtonTextScript : MonoBehaviour
{
    public string textToDisplay;
    public GameObject button;

    // Use this for initialization
    void Start()
    {
        TextMesh textMesh = (TextMesh)button.GetComponent("TextMesh");
        textMesh.text = textToDisplay;
    }
}
