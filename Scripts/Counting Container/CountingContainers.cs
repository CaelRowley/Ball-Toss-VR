using UnityEngine;
using System.Collections;

public class CountingContainers : MonoBehaviour
{

    GameObject[] containersInArea;
    public string containerTag;
    private int cupCount;

    public void howManyContainersAreInTheArea()
    {
        cupCount = 0; 
        GameObject[] containersInArea = GameObject.FindGameObjectsWithTag(containerTag);
        foreach(GameObject container in containersInArea)
        {
            cupCount++;
        }
    }
    public bool verifyCanJump()
    {
        howManyContainersAreInTheArea();
        if(cupCount > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
