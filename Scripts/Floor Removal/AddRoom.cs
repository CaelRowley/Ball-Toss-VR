using UnityEngine;
using System.Collections;

public class AddRoom : MonoBehaviour {
    public string roofName = "Roof Stage 2";
    GameObject roof;
    void Start()
    {
        roof = GameObject.Find(roofName);
    }    
    private void OnCollisionEnter(Collision collider)
    {        
        roof.SetActive(true);
    }
}
