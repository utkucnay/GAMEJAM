using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelDetec : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Engel")
        {
            //Todo
            Debug.Log("Oyunu Bitir");
        }
    }
}
