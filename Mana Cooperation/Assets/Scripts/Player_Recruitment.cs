using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(Player_Team())]
public class Player_Recruitment : MonoBehaviour
{
    public Player_Team myTeam;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("npc_unit"))
        {
            NPC_Captured Npc = other.GetComponent<NPC_Captured>();

            Npc.OnCaptured(myTeam.TeamNo);
        }
    }
}
