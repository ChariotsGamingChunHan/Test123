using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movements : MonoBehaviour
{
    public float MovementSpeed_SlowingFactor;
    public float MovementSpeed;
    public float DragLimit = 5f;
    public FloatingJoystick variableJoystick;
    public Rigidbody rb;
    public bool isMoving;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            rb.drag = 0;
            isMoving = true;
            Vector3 moveVector = (Vector3.right * variableJoystick.Horizontal + Vector3.forward * variableJoystick.Vertical) * MovementSpeed * Time.deltaTime;
            if (moveVector != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveVector);
                transform.Translate(moveVector * Time.smoothDeltaTime, Space.World);

            }
        }
        else
        {
            if (rb.drag >= DragLimit) return;
            isMoving = false;
            rb.drag += Time.deltaTime * MovementSpeed_SlowingFactor;
        }
    }
}
