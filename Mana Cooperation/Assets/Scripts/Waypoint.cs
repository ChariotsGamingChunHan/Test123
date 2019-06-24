using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public NPC_Movements myparent;
    public SphereCollider mycol;
    public List<GameObject> SurroundingObjects = new List<GameObject>();
    public bool locatedPosition;
    public bool MoveToPlayerr;
    public void OnLocatingPoisition(Vector3 _pos)
    {
        mycol.enabled = false;
        locatedPosition = false;
        Vector3 Pos = myparent.transform.TransformPoint(_pos);
        SurroundingObjects = new List<GameObject>();
        transform.position = new Vector3(Pos.x,0,Pos.z);
        mycol.enabled = true;
        StartCoroutine(CheckingSurrounding());
    }

    IEnumerator CheckingSurrounding()
    {
        yield return new WaitForSeconds(0.15f);

        if (SurroundingObjects.Count <= 0)
        {
            myparent.RelocatePosition();
         
        }
        else
        {
            for (int i = 0; i < SurroundingObjects.Count; i++)
            {

                if (SurroundingObjects[i].CompareTag("ground"))
                {
                    locatedPosition = true;
                    if (SurroundingObjects[i].CompareTag("obstacles"))
                    {
                        locatedPosition = false;
                    }

                    if (locatedPosition)
                    {
                        Debug.Log("Located a position");

                        myparent.MovingToLocatedPosition(transform.position);

                        break;
                    }
                }

                if (!locatedPosition)
                {
                    myparent.RelocatePosition();

                    //myparent.MovingToLocatedPosition(transform.position);

                    break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground")|| other.gameObject.CompareTag("obstacles"))
        {
            SurroundingObjects.Add(other.gameObject);

            
        }
    }

}
