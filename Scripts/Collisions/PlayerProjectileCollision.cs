using UnityEngine;

public class PlayerProjectileCollision : MonoBehaviour
{
    public GameObject playerStatusGameObject;
    private PlayerStatus playerStatus;

    public string playerTag = "Player";
    public string[] targetTags;
    private bool hitTarget;

    public float collisionTimeRequired = 1.0f;
    public string colliderTag = "Player";
    public string messageToSend = "InstantiateExplosion";

    private bool continueTimer = false;
    private float collisionCurrentTime = 0.0f;

    void Start()
    {
        playerStatusGameObject = GameObject.FindGameObjectWithTag(playerTag);
        playerStatus = (PlayerStatus)playerStatusGameObject.GetComponent("PlayerStatus");
    }

    void OnCollisionEnter(Collision collider)
    {
        continueTimer = true;
    }

    void OnCollisionExit(Collision collider)
    {
        continueTimer = false;
        collisionCurrentTime = 0.0f;
    }

    void OnCollisionStay(Collision collider)
    {
        collisionCurrentTime += Time.deltaTime;

        if(collisionCurrentTime > collisionTimeRequired && continueTimer)
        {
            for(int i = 0; i < targetTags.Length; i++)
            {
                if(collider.gameObject.CompareTag(targetTags[i]))
                {
                    hitTarget = true;
                }
            }
        }
    }

    void OnDestroy()
    {
        if(hitTarget)
            playerStatus.TargetHit();
        else
            playerStatus.TargetMiss();
    }
}
