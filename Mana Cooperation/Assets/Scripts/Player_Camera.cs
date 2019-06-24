using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    public Transform TargetPlayer;
    public float LerpSpeed = 3;
    public float Rotation_LerpSpeed = 0.5f;
    public Player_Movements player_Movements;
    private void Awake()
    {
        if(TargetPlayer!=null)
        {
            player_Movements = TargetPlayer.GetComponent<Player_Movements>();
        }
    }

    void Update()
    {
        if (TargetPlayer == null) return;

        if (player_Movements.isMoving)
        {
            Vector3 smoothedPos = Vector3.Lerp(transform.position, TargetPlayer.position, LerpSpeed * Time.deltaTime);

            //Vector3 direction = TargetPlayer.position - transform.position;
            //Quaternion smoothedRot = Quaternion.LookRotation(direction);
          
            transform.position = smoothedPos;
            //transform.rotation = Quaternion.Slerp(transform.rotation, smoothedRot , LerpSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Slerp(transform.rotation, TargetPlayer.rotation, Rotation_LerpSpeed* Time.deltaTime);
        }
        else
        {
            //Debug.LogWarning("TargetPlayer is null");
        }
    }
}
