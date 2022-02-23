using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDetec : MonoBehaviour
{
    public float Distance;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RoadTrigger")
        {
            other.gameObject.transform.parent.gameObject.transform.position += new Vector3(0,0,2*Distance);
        }
    }
}
