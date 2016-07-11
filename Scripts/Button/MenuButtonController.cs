using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public float highlightDistance;
    public float buttonSpeed;
    public float buttonDelay;
    public string buttonType;

    private bool isButtonHighlighted = false;
    private bool isButtonClicked = false;
    private bool isButtonPressedIn = false;

    private float highlightDistanceMoved = 0f;
    private float clickDistanceMoved = 0f;
    private Vector3 defaultPosition;
    private Button button;

    void Start()
    {
        defaultPosition = transform.localPosition;
    }

    void Update()
    {
        // Doesn't allow the button to move behind its starting position
        if(transform.localPosition.x > defaultPosition.x && !isButtonClicked)
        {
            //Debug.Log("reset");
            //ResetPosition();
        }

        // Move button forward
        if(isButtonHighlighted && !isButtonClicked)
        {
            if(highlightDistanceMoved < highlightDistance)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(buttonSpeed * Time.deltaTime, 0, 0);
                highlightDistanceMoved += Vector3.Distance(oldPosition, transform.position);
            }

            isButtonHighlighted = false;
        }
        // Move button back
        else if(!isButtonHighlighted && !isButtonClicked)
        {
            if(highlightDistanceMoved > 0)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(-buttonSpeed * Time.deltaTime, 0, 0);
                highlightDistanceMoved -= Vector3.Distance(oldPosition, transform.position);
            }
        }
        else if(isButtonClicked)
        {
            // Move button Back
            if(!isButtonPressedIn)
            {
                if(transform.localPosition.x >= defaultPosition.x)
                    isButtonPressedIn = true;

                if((clickDistanceMoved + highlightDistanceMoved) > 0)
                {
                    Vector3 oldPosition = transform.position;
                    transform.Translate(-buttonSpeed * Time.deltaTime * 2, 0, 0);
                    clickDistanceMoved -= Vector3.Distance(oldPosition, transform.position);
                }
            }
            // Move button forward
            else if(isButtonPressedIn)
            {
                if((clickDistanceMoved + highlightDistanceMoved) >= highlightDistance)
                {
                    isButtonClicked = false;
                    isButtonPressedIn = false;
                }

                if((clickDistanceMoved + highlightDistanceMoved) < highlightDistance)
                {
                    Vector3 oldPosition = transform.position;
                    transform.Translate(buttonSpeed * Time.deltaTime * 2, 0, 0);
                    clickDistanceMoved += Vector3.Distance(oldPosition, transform.position);
                }
            }
        }
    }

    public void ClickButton()
    {
        isButtonClicked = true;
        StartCoroutine("UseButton");
    }

    public void HighlightButton()
    {
        isButtonHighlighted = true;
    }

    private IEnumerator UseButton()
    {
        button = (Button)transform.GetComponent(buttonType);
        yield return new WaitForSeconds(buttonDelay);
        button.Activate();
    }

    private void ResetPosition()
    {
        transform.localPosition = defaultPosition;
    }
}
