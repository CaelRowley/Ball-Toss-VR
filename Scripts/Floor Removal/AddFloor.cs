using UnityEngine;
using System.Collections;

public class AddFloor : MonoBehaviour {
    public string floorName = "Floor Stage 1";
    private GameObject floor;
    void Start()
    {
        floor = GameObject.Find(floorName);
    }    
    private void OnCollisionEnter(Collision collider)
    {
        floor.SetActive(true);
    }
}
