using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelDestror : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
