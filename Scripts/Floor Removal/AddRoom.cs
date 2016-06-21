using UnityEngine;
using System.Collections;

public class AddRoom : MonoBehaviour {
    public string coilliderTag = "Player";
    public string roofName = "Roof Stage 2";
    private GameObject roof;

    void Start()
    {
        roof = GameObject.Find(roofName);
    }    
    private void OnCollisionEnter(Collision collider)
    {
        // Add verify player tag
        if(collider.gameObject.CompareTag(coilliderTag))
        {
            roof.SetActive(true);
        }       
    }
}
