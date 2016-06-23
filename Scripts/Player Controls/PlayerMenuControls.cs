using UnityEngine;
using System.Collections;

public class PlayerMenuControls : MonoBehaviour
{
    private Vector3 targetPosition;
    private MenuButtonControl menuButtonControl;

    private void Start()
    {

    }

    private void Update()
    {
        float rayLength = 100f;

        RaycastHit objectHit;
        targetPosition = transform.forward * rayLength;

        if(Physics.Raycast(transform.position, transform.forward, out objectHit, rayLength))
        {
            if(objectHit.transform.CompareTag("Button"))
            {
                menuButtonControl = (MenuButtonControl)objectHit.transform.GetComponent("MenuButtonControl");
                menuButtonControl.HighlightButton();

                if(GvrViewer.Instance.Triggered)
                {
                    menuButtonControl.ClickButton();
                }
            }
            targetPosition = objectHit.point;
            Debug.DrawLine(targetPosition, transform.position, Color.red, 1.0f, false);
        }
    }
}