using UnityEngine;
using System.Collections;

public class CountingContainers : MonoBehaviour
{

    GameObject[] containersInArea;
    public string containerTag;
    private int cupCount;

    public void howManyContainersAreInTheArea()
    {
        cupCount = GameObject.FindGameObjectsWithTag(containerTag).Length;
        //GameObject[] containersInArea = GameObject.FindGameObjectsWithTag(containerTag);
        //cupCount = GameObject.FindGameObjectsWithTag(containerTag).Length
        //foreach(GameObject container in containersInArea)
        //{
        //  cupCount++;
        //}
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
