using UnityEngine;
using System.Collections;

public class MenuPositionController : MonoBehaviour
{
    public float menuHeight;
    public float moveSpeed;

    private bool showMenu = false;
    private float distanceMoved = 0f;

    public AudioClip audioClip;
    private AudioSource audioSource;

    void Start()
    {
        GameObject child = new GameObject("SFX Player");
        child.transform.parent = gameObject.transform;
        audioSource = child.AddComponent<AudioSource>();
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
            else if(distanceMoved >= menuHeight)
                audioSource.Stop();
        }
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
        audioSource.PlayOneShot(audioClip);
    }

    public void HideMenu()
    {
        showMenu = false;
    }
}
