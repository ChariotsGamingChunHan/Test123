using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FuckBotScript : MonoBehaviour
{
    public NavMeshAgent MyAgent;
    public Transform MyTarget;
    
    void Start()
    {
    
        MyAgent = GetComponent<NavMeshAgent>();

        //MyAgent.Warp(transform.position);
    }

    private void Update()
    {
        if (MyAgent == null) return;

        MyAgent.SetDestination(MyTarget.position);
    }

}
