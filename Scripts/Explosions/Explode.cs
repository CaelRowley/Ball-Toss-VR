using System.Collections;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public Transform spawnedPrefab;
    public float timeTaken;

    public void InstantiateExplosion()
    {
        StartCoroutine("DestroyAfterTime");
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(timeTaken);
        Instantiate(spawnedPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
