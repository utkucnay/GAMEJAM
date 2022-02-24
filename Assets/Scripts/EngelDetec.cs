using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelDetec : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Yemek")
        {
            //Todo Kilo Artýrma
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Engel")
        {
            Time.timeScale = 0;
            Debug.Log("Oyunu Bitir");
        }
    }
}
