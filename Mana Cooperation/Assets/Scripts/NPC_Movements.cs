using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Movements : MonoBehaviour
{
    [Header("Navmesh Setups")]
    public Waypoint WayPoint_Prefab;
    public NavMeshAgent me;
    public float MovementSpeed = 2f;
    public float StoppingDistance = 0.1f;
    public float MaxTravelRange = 5f;
    bool isLocated = false;
    bool arrivedDestination = false;
    Vector3 destinationPoint;
    [Space]
    [Header("Timing Setup")]
    public float RepeatingPatrol = 5f;
    public Transform TargetObjectTest;

    private void Awake()
    {
        if(me==null)
        {
            me = GetComponent<NavMeshAgent>();
            me.speed = MovementSpeed;
        }
    }

    private void Start()
    {
        WayPoint_Prefab.transform.parent = null;

        LocatePosition();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LocatePosition();
        }

        ///
        if(me.hasPath)
        {
            //Debug.Log(me.remainingDistance);
            if(me.remainingDistance <= StoppingDistance)
            {
                me.ResetPath();
                me.velocity = Vector3.zero;
                me.speed = 0;

                StartCoroutine(StartCyclePatrol());
            }
        }
        else
        {

        }
    }

    IEnumerator StartCyclePatrol()
    {
        yield return new WaitForSeconds(RepeatingPatrol);

        LocatePosition();
    }

    void LocatePosition()
    {
        float X, Z;
        X = Random.Range(-MaxTravelRange, MaxTravelRange);
        Z = Random.Range(-MaxTravelRange, MaxTravelRange);

        Vector3 Selected_Position = transform.InverseTransformDirection(X, 0f, Z);

        Debug.DrawRay(transform.position, Selected_Position, Color.blue, 5f);

        WayPoint_Prefab.OnLocatingPoisition(Selected_Position);

    }

    public void RelocatePosition()
    {
        //Debug.Log("Relocating a position");

        LocatePosition();
    }

    public void MovingToLocatedPosition(Vector3 _pos)
    {
        me.speed = MovementSpeed;
        me.SetDestination(_pos);
    }
}
