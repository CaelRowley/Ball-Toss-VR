using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeSceneOnCollision : MonoBehaviour
{
    public float delay;
    public string sceneName;

    private void OnCollisionEnter(Collision colllider)
    {
        StartCoroutine("ChangeScene");
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
