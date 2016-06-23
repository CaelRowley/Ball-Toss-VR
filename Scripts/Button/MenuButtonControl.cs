using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour
{
    public float highlightDistance;
    public float buttonSpeed;

    private bool isButtonHighlighted = false;
    private bool isButtonClicked = false;

    private float distanceMoved = 0f;

    void Update()
    {
        if(isButtonHighlighted)
        {
            if(distanceMoved < highlightDistance)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(1 * Time.deltaTime, 0, 0);
                distanceMoved += Vector3.Distance(oldPosition, transform.position);
            }

            isButtonHighlighted = false;
        }
        else
        {
            if(distanceMoved > 0)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(-1 * Time.deltaTime, 0, 0);
                distanceMoved -= Vector3.Distance(oldPosition, transform.position);
            }
        }
    }

    public void ClickButton()
    {
        SceneManager.LoadScene("Level 1 Office");
    }

    public void HighlightButton()
    {
        isButtonHighlighted = true;
    }

    public void ResetButtonPosition()
    {

    }
}
