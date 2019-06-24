using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GlobalGameManager;
    public List<GameObject> TeamPlayers = new List<GameObject>();

    private void Awake()
    {
        GlobalGameManager = this;
    }
}
