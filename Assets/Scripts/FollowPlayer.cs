using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool Lock;
    public bool Move;
    public GameObject FollowObject;
    private Vector3 Distance;
    void Start()
    {
        Distance = transform.position - FollowObject.transform.position;
        Lock = false;
        Move = false;
    }

    void Update()
    { 
        if (!Lock)
        {
            transform.position = new Vector3(transform.position.x, Distance.y + FollowObject.transform.position.y, Distance.z + FollowObject.transform.position.z);
        }
        else if(Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Distance.y + FollowObject.transform.position.y, Distance.z + FollowObject.transform.position.z),0.1f);
            if (transform.position == new Vector3(transform.position.x, Distance.y + FollowObject.transform.position.y, Distance.z + FollowObject.transform.position.z))
            {
                Move = false;
                Lock = false;
            }
        }
    }
    
}
