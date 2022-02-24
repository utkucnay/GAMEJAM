using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject FollowObject;
    private Vector3 Distance;
    void Start()
    {
        Distance = transform.position - FollowObject.transform.position;
    }

    void Update()
    { 
        transform.position = Distance + FollowObject.transform.position;
    }
}
