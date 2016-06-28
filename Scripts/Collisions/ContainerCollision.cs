using UnityEngine;
using System.Collections;

public class ContainerCollision : MonoBehaviour
{
    public string colliderTag = "Player";
    public string messageToSend = "InstantiateExplosion";

    void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.CompareTag(colliderTag))
        {
            SendMessageUpwards(messageToSend);
        }
    }
}
