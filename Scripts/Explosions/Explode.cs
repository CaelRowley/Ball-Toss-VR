using UnityEngine;

public class Explode : MonoBehaviour
{
    public Transform spawnedPrefab;

    public void InstantiateExplosion()
    {
        Debug.Log("InstantiateExplosion");
        Instantiate(spawnedPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
