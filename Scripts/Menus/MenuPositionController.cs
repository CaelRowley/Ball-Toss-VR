using UnityEngine;
using System.Collections;

public class MenuPositionController : MonoBehaviour
{
    public float menuHeight;
    public float moveSpeed;

    private bool showMenu = false;
    private float distanceMoved = 0f;

    void Start()
    {

    }

    void Update()
    {
        if(showMenu)
        {
            if(distanceMoved < menuHeight)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(0, moveSpeed * Time.deltaTime, 0);
                distanceMoved += Vector3.Distance(oldPosition, transform.position);
            }
        }
        // Move button back

        else
        {
            if(distanceMoved > 0)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
                distanceMoved -= Vector3.Distance(oldPosition, transform.position);
            }
        }
    }

    public void ShowMenu()
    {
        showMenu = true;
    }

    public void HideMenu()
    {
        showMenu = false;
    }
}
