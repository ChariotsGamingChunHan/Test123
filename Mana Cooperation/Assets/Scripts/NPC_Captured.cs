using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Captured : MonoBehaviour
{
    [Header("1 = Team01, 2 = Team02")]
    public Material[] myBodyColors;
    public NPC_Movements WanderScript;
    public int TeamNo;

    public void OnCaptured(int _team)
    {
        TeamNo = _team;
        if(TeamNo==1)
        {
            gameObject.tag = "Team01";
        }
        else
        {

        }

        GetComponent<Renderer>().material = myBodyColors[_team - 1];
    }
}
