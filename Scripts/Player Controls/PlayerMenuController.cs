using UnityEngine;
using System.Collections;

public class PlayerMenuController : MonoBehaviour
{
    private Vector3 targetPosition;
    private MenuButtonController menuButtonControl;

    public AudioClip menuSFX;
    public AudioClip menuClickSFX;
    private AudioSource audioSource;
    private bool isAudioPlaying = false;

    public float audioLength;
    private float currentTime = 0f;

    private void Start()
    {
        GameObject child = new GameObject("SFX Player");
        child.transform.parent = gameObject.transform;
        audioSource = child.AddComponent<AudioSource>();
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
                menuButtonControl = (MenuButtonController)objectHit.transform.GetComponent("MenuButtonController");
                menuButtonControl.HighlightButton();
                playSFX(menuSFX);

                if(GvrViewer.Instance.Triggered)
                {
                    audioSource.PlayOneShot(menuClickSFX);
                    menuButtonControl.ClickButton();
                }
            }
            else if(isAudioPlaying)
            {
                audioSource.Stop();
                isAudioPlaying = false;
            }
            targetPosition = objectHit.point;
            Debug.DrawLine(targetPosition, transform.position, Color.red, 1.0f, false);
        }
        else if(isAudioPlaying)
        {
            audioSource.Stop();
            isAudioPlaying = false;
        }
    }

    private void playSFX(AudioClip sfx)
    {
        if(!isAudioPlaying)
        {
            StartCoroutine("SFXTimer");
            audioSource.PlayOneShot(sfx);
            isAudioPlaying = true;
        }

        else if(currentTime >= audioLength)
        {
            StopCoroutine("SFXTimer");
            audioSource.Stop();
            currentTime = 0;
        }
    }

    // Adds 1 to currentTime every second
    private IEnumerator SFXTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(audioLength);
            currentTime += audioLength;
        }
    }
}