using UnityEngine;
using System.Collections;

public class AudioOnCollision : MonoBehaviour
{
    public float volume;
    public AudioClip audioClip;

    private AudioSource audioSource;

    void Start()
    {
        GameObject child = new GameObject("Music Player");
        child.transform.parent = gameObject.transform;
        audioSource = child.AddComponent<AudioSource>();
        audioSource.volume = volume;
    }

    void OnCollisionEnter(Collision collider)
    {
        audioSource.PlayOneShot(audioClip);
    }

    void OnTriggerEnter(Collider collider)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
