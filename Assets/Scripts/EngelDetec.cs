using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelDetec : MonoBehaviour
{
    public CharMovement charMovement;
    private void Start()
    {
        charMovement = gameObject.GetComponent<CharMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Yemek")
        {
            //Todo Kilo Artýrma
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Engel")
        {
            if (charMovement.GetForwardMovement())
            {
                Destroy(other.gameObject);
            }
            else
            {
                Time.timeScale = 0;
                Debug.Log("Oyunu Bitir");
                charMovement.SetLock();
            }
        }
    }
}
