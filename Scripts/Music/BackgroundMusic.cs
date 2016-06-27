using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public float audioLength;
    public AudioClip audioClip;
    public float volume;

    private double nextLoopTime;
    private int toggle = 0;
    private AudioSource[] audioSources = new AudioSource[2];
    private AudioClip[] audioClips = new AudioClip[2];

    // Creates audio sources as children to Player
    private void Start()
    {
        for(int i = 0; i < audioClips.Length; i++)
            audioClips[i] = audioClip;

        for(int i = 0; i < 2; i++)
        {
            GameObject child = new GameObject("Music Player");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent<AudioSource>();
            audioSources[i].volume = volume;
        }

        nextLoopTime = AudioSettings.dspTime + 1.0f;
    }

    // Plays audio clip after the loop time and switches the index for the next audio clip
    private void Update()
    {
        double currentTime = AudioSettings.dspTime;
        if(currentTime > nextLoopTime)
        {
            audioSources[toggle].clip = audioClips[toggle];
            audioSources[toggle].PlayScheduled(nextLoopTime);
            nextLoopTime += audioLength;
            toggle = 1 - toggle;
        }
    }
}
