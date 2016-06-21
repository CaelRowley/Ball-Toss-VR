using UnityEngine;
using System.Collections;

public class CountingContainers : MonoBehaviour
{

    GameObject[] containersInArea;
    public string containerTag = "Red Cup Stage 1 Level 1";
    private int cupCount;

    public void howManyContainersAreInTheArea()
    {
        cupCount = 0; 
        GameObject[] containersInArea = GameObject.FindGameObjectsWithTag(containerTag);
        foreach(GameObject container in containersInArea)
        {
            cupCount++;
            //Debug.Log("Cup count: " + cupCount);
        }
    }
    //public void setContainerTag(string changedContainerTag)
    //{
    //    changedContainerTag = containerTag;
    //}
    public bool verifyCanJump()
    {
        howManyContainersAreInTheArea();
        //Debug.Log("Cup count: " + cupCount);
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
