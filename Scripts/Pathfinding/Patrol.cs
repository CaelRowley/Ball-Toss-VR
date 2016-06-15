using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if(points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        if(agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
