using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed;
    public float jumpUpdateTime;
    public float jumpFilterStrength;
    public float jumpShakeLimit;

    public bool canJump = false;
    public bool canJumpStage2 = false;

    private float jumpMinShakeFilter;
    private Vector3 currentAcceleration = Vector3.zero;
    private Vector3 startAcceleration;
    private Vector3 shake;

    private TransitionBetweenStages Transition = new TransitionBetweenStages();
    private CountingContainers countingContainers = new CountingContainers();
    private CountingContainers countingContainers2 = new CountingContainers();



    public AudioClip audioClipJump;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        countingContainers2.containerTag="Red Cup Stage 1 Level 2";

        jumpMinShakeFilter = jumpUpdateTime / jumpFilterStrength;

        // Creates audio source for player
        GameObject child = new GameObject("Player");
        child.transform.parent = gameObject.transform;
        audioSource = child.AddComponent<AudioSource>();
    }

    void Update()
    {
        canJump = countingContainers.verifyCanJump();
        canJumpStage2 = countingContainers2.verifyCanJump();
        //Debug.Log("Can jump S2: " + canJumpStage2);

        if(canJump)
        {
            Jump();
        }
        if(canJumpStage2)
        {
            Transition.level2 = true;
            Jump();
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
            Transition.Transition();
        }

        // The player jumps when space is pressed
        if(Input.GetKeyDown("space"))
        {
            audioSource.PlayOneShot(audioClipJump);
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime / 2, Space.World);
            Transition.Transition();

        }
    }

}
