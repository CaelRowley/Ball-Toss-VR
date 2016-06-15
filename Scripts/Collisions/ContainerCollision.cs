using UnityEngine;
using System.Collections;

public class ContainerCollision : MonoBehaviour
{
    public float collisionTimeRequired = 1.0f;
    public string colliderTag = "Player";
    public string messageToSend = "InstantiateExplosion";

    private bool continueTimer = false;
    private float collisionCurrentTime = 0.0f;

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
            if(collider.gameObject.CompareTag(colliderTag))
            {
                SendMessageUpwards(messageToSend);
            }
        }
    }
}
