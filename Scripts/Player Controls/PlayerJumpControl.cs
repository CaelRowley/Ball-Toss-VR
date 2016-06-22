using UnityEngine;
using System.Collections;

public class PlayerJumpControl : MonoBehaviour
{

    private bool canJump = false;
    private bool canJumpStage2 = false;
    private bool stage2 = true;

    private TransitionBetweenStages transition;
    private CountingContainers countingContainers;
    private CountingContainers countingContainers2;

    public GameObject transitionGameObject;
    public GameObject countingContainersGameObject;
    public GameObject countingContainers2GameObject;

    // Use this for initialization
    void Start()
    {
        //((PlayerJump)gameObject.GetComponent<PlayerJump>()).enabled = false;

        transition = (TransitionBetweenStages)transitionGameObject.GetComponent("TransitionBetweenStages");
        countingContainers = (CountingContainers)countingContainersGameObject.GetComponent("CountingContainers");
        countingContainers2 = (CountingContainers)countingContainers2GameObject.GetComponent("CountingContainers");
    }

    // Update is called once per frame
    void Update()
    {
        canJump = countingContainers.verifyCanJump();
        canJumpStage2 = countingContainers2.verifyCanJump();

        if(canJump)
        {
            gameObject.GetComponent<PlayerJump>().canTransition = true;
        }
        if(canJumpStage2)
        {
            if(stage2)
            {
                transition.level2 = true;
                stage2 = false;
            }
            gameObject.GetComponent<PlayerJump>().canTransition = true;
        }
    }

    public void Transition()
    {
        transition.Transition();
    }
}
