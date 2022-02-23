using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDetec : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RoadTrigger")
        {
            Destroy(other.gameObject.transform.parent.gameObject);

        }

    }

}
