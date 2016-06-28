using UnityEngine;

public class PlayerProjectileCollision : MonoBehaviour
{
    public GameObject playerStatusGameObject;
    private PlayerStatus playerStatus;

    public string playerTag = "Player";
    public string[] targetTags;
    private bool hitTarget;

    public string messageToSend = "InstantiateExplosion";

    void Start()
    {
        playerStatusGameObject = GameObject.FindGameObjectWithTag(playerTag);
        playerStatus = (PlayerStatus)playerStatusGameObject.GetComponent("PlayerStatus");
    }

    void OnCollisionEnter(Collision collider)
    {
        for(int i = 0; i < targetTags.Length; i++)
        {
            if(collider.gameObject.CompareTag(targetTags[i]))
            {
                hitTarget = true;
                Destroy(gameObject, 0.1f);
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
