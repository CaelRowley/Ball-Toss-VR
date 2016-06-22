using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed;
    public float jumpUpdateTime;
    public float jumpFilterStrength;
    public float jumpShakeLimit;

    private float jumpMinShakeFilter;
    private Vector3 currentAcceleration = Vector3.zero;
    private Vector3 startAcceleration;
    private Vector3 shake;

    public AudioClip audioClipJump;
    private AudioSource audioSource;

    public GameObject PlayerJumpControlObject;
    private PlayerJumpControl playerJumpControl;

    public bool canTransition = false;

    // Use this for initialization
    void Start()
    {
        playerJumpControl = (PlayerJumpControl)PlayerJumpControlObject.GetComponent("PlayerJumpControl");
        jumpMinShakeFilter = jumpUpdateTime / jumpFilterStrength;

        // Creates audio source for player
        GameObject child = new GameObject("Player");
        child.transform.parent = gameObject.transform;
        audioSource = child.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Finds the current shake of the accelerometer  
        startAcceleration = Input.acceleration;
        currentAcceleration = Vector3.Lerp(currentAcceleration, startAcceleration, jumpMinShakeFilter);
        shake = startAcceleration - currentAcceleration;

        // The player jumps when the shake goes over the shake limit
        if(shake.sqrMagnitude >= jumpShakeLimit)
        {
            audioSource.PlayOneShot(audioClipJump);
            transform.Translate((Vector3.up * jumpSpeed * Time.deltaTime) / 4, Space.World);
            if(canTransition)
            {
                playerJumpControl.Transition();
                canTransition = false;
            }
        }

        // The player jumps when space is pressed
        if(Input.GetKeyDown("space"))
        {
            audioSource.PlayOneShot(audioClipJump);
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime / 4, Space.World);
            if(canTransition)
            {
                playerJumpControl.Transition();
                canTransition = false;
            }
        }

    }
}
