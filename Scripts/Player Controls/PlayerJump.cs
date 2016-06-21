using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed;
    public float jumpUpdateTime;
    public float jumpFilterStrength;
    public float jumpShakeLimit;

    private bool canJump = false;
    private bool canJumpStage2 = false;
    private bool stage2 = true;

    private float jumpMinShakeFilter;
    private Vector3 currentAcceleration = Vector3.zero;
    private Vector3 startAcceleration;
    private Vector3 shake;

    private TransitionBetweenStages transition;
    private CountingContainers countingContainers;
    private CountingContainers countingContainers2;

    public GameObject transitionGameObject;
    public GameObject countingContainersGameObject;
    public GameObject countingContainers2GameObject;

    public AudioClip audioClipJump;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        transition = (TransitionBetweenStages) transitionGameObject.GetComponent("TransitionBetweenStages");
        countingContainers = (CountingContainers) countingContainersGameObject.GetComponent("CountingContainers");
        countingContainers2 = (CountingContainers) countingContainers2GameObject.GetComponent("CountingContainers");

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

        if(canJump)
        {
            Jump();
        }
        if(canJumpStage2)
        {
            if(stage2)
            {
                transition.level2 = true;
                stage2 = false;
            } 
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
            transition.Transition();
        }

        // The player jumps when space is pressed
        if(Input.GetKeyDown("space"))
        {
            audioSource.PlayOneShot(audioClipJump);
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime / 2, Space.World);
            transition.Transition();

        }
    }

}
