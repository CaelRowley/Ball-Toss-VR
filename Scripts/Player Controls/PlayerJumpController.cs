using UnityEngine;
using System.Collections;

public class PlayerJumpController : MonoBehaviour
{

    private bool canJump = false;
    private bool canJumpStage2 = false;
    private bool stage1 = true;
    private bool stage2 = true;

    private TransitionBetweenStages transition;
    private CountingContainers countingContainers;
    private CountingContainers countingContainers2;
    private TextureFlash textureFlash;

    public GameObject transitionGameObject;
    public GameObject countingContainersGameObject;
    public GameObject countingContainers2GameObject;
    public GameObject textureFlashGameObject;

    public AudioClip audioClipReadyToJump;
    private AudioSource audioSource;
    public float audioClipVolume;

    // Use this for initialization
    void Start()
    {
        //((PlayerJump)gameObject.GetComponent<PlayerJump>()).enabled = false;

        transition = (TransitionBetweenStages)transitionGameObject.GetComponent("TransitionBetweenStages");
        countingContainers = (CountingContainers)countingContainersGameObject.GetComponent("CountingContainers");
        countingContainers2 = (CountingContainers)countingContainers2GameObject.GetComponent("CountingContainers");
        textureFlash = (TextureFlash)textureFlashGameObject.GetComponent("TextureFlash");

        GameObject child = new GameObject("SFX Player");
        child.transform.parent = gameObject.transform;
        audioSource = child.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        canJump = countingContainers.verifyCanJump();
        canJumpStage2 = countingContainers2.verifyCanJump();

        if(canJump && stage1)
        {
            StartCoroutine("PlaySoundTwice");
            textureFlash.StartTextureFlash();
            gameObject.GetComponent<PlayerJump>().canTransition = true;
            stage1 = false;
        }
        if(canJumpStage2 && stage2)
        {
            StartCoroutine("PlaySoundTwice");
            transition.level2 = true;
            gameObject.GetComponent<PlayerJump>().canTransition = true;
            stage2 = false;
        }
    }

    public void Transition()
    {
        transition.Transition();
    }

    private IEnumerator PlaySoundTwice()
    {
        audioSource.PlayOneShot(audioClipReadyToJump);
        yield return new WaitForSeconds(0.2f);
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipReadyToJump);
    }
}
