using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_FollowLeader : MonoBehaviour
{
    public NavMeshAgent myAgent;
    public NPC_Movements myWander;
    public float FollowSpeed;
    public Transform Leader;
    private bool isFollowing;

    public void FollowLeader(int _teamPlayerNo)
    {
        //Debug.Log("Enabling following mechanism");
        //myAgent.ResetPath();
        //Leader = GameManager.GlobalGameManager.TeamPlayers[_teamPlayerNo].transform;
        //myAgent.speed = FollowSpeed;
        
        //if (!isFollowing) isFollowing = true;
    }

    private void Update()
    {
        //if(isFollowing)
        //{
        //    myAgent.SetDestination(Leader.position);
        //}
    }
}
