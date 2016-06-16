using UnityEngine;

public class ContactCollision : MonoBehaviour
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

