using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelDetec : MonoBehaviour
{
    Animator animator;
    public CharMovement charMovement;
    public float BuyumeDerecesi;
    public GameObject ParcalnmýsTabak;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        charMovement = gameObject.GetComponent<CharMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Yemek")
        {
            this.gameObject.transform.localScale += new Vector3(BuyumeDerecesi, BuyumeDerecesi, BuyumeDerecesi); 
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Engel")
        {
            if (charMovement.GetForwardMovement())
            {
                Destroy(other.gameObject);
                Instantiate(ParcalnmýsTabak,other.gameObject.transform.position,Quaternion.identity);
            }
            else
            {
                animator.SetBool("Lock",true);
                charMovement.SetSpeed(0);
                Debug.Log("Oyunu Bitir");
                charMovement.SetLock();
            }
        }
        if (other.gameObject.tag =="Finish")
        {
            charMovement.SetLock();
            animator.SetBool("Sevinc",true);
            charMovement.SetSpeed(0);
        }
    }
}
