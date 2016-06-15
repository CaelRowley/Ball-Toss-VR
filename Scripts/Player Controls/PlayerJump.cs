﻿using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed;
    public float jumpUpdateTime;
    public float jumpFilterStrength;
    public float jumpShakeLimit;
    public bool canJump = true;

    private float jumpMinShakeFilter;
    private Vector3 currentAcceleration = Vector3.zero;
    private Vector3 startAcceleration;
    private Vector3 shake;

    private int stage = 1;

    public AudioClip audioClipJump;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        jumpMinShakeFilter = jumpUpdateTime / jumpFilterStrength;

        // Creates audio source for player
        GameObject child = new GameObject("Player");
        child.transform.parent = gameObject.transform;
        audioSource = child.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canJump)
        {
            Jump();
            //canJump = false;
        }
    }

    private void Jump()
    {
        // Finds the current shake of the accelerometer  
        startAcceleration = Input.acceleration;
        currentAcceleration = Vector3.Lerp(currentAcceleration, startAcceleration, jumpMinShakeFilter);
        shake = startAcceleration - currentAcceleration;

        // The player jumps when the shake goes over the shake limit
        if(shake.sqrMagnitude >= jumpShakeLimit)
        {
            audioSource.PlayOneShot(audioClipJump);
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime, Space.World);
        }

        // The player jumps when space is pressed
        if(Input.GetKeyDown("space"))
        {
            audioSource.PlayOneShot(audioClipJump);
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime/2, Space.World);
            if(stage == 1)
            {
                ToggleObjectVisiblity.ToggleObjectVisible("Floor Stage 1", false);
                stage++;
            }
            else if(stage==2)
            {
                ToggleObjectVisiblity.ToggleObjectVisible("Floor Stage 2", false);
                stage++;
            }
            
        }
    }

}