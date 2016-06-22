using UnityEngine;
using System.Collections;

public class TextureFlash : MonoBehaviour
{
    public Material firstTexture;
    public Material secondTexture;
    public float delay;

    private int currentTime;
    private Material[] materials = new Material[2];

    void Start()
    {
        materials[0] = firstTexture;
        materials[1] = secondTexture;
    }

    // Waits for the delay then switches textures
    private IEnumerator SwitchMaterial()
    {
        int numSwitch = 0;
        while(true)
        {
            yield return new WaitForSeconds(delay);
            GetComponent<Renderer>().material = materials[numSwitch];
            numSwitch = 1 - numSwitch;
        }
    }

    public void StartTextureFlash()
    {
        StartCoroutine("SwitchMaterial");
    }
}
