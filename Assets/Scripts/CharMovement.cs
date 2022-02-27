using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharMovement : MonoBehaviour
{
    enum stage
    {
        mid,
        left,
        right
    };



    public float tmp;

    public GameObject Camera;

    bool Lock;
    bool ForwardMovement;

    Rigidbody rb;
    Animator animator;

    stage currentstage;

    float y;

    public GameObject Failed;

    public Transform MidLoc;
    public Transform LeftLoc;
    public Transform RightLoc;

    public GameObject Winner;

    float timeLimit;
    float pastTime;

    public float CharSpeed;
    public float CharSpeedMultiplier;

    public float KuculmeDerecesi;
    public float BuyumeDerecesi;
    public GameObject ParcalnmýsTabak;

    public Text AgirlikText;
    int Agirlik;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentstage = stage.mid;
        timeLimit = 10;
        pastTime = 0;
        Lock = false;
        Agirlik = 130;
        AgirlikText.text = Agirlik + " lbs";
        Lock = true;
    }

    public void SetSpeed(float speed)
    {
        CharSpeed = speed;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    public bool GetForwardMovement()
    {
        return ForwardMovement;
    }

    public void SetLock()
    {
        Lock = true;
    }

    public void SetFalseLock()
    {
        Lock = false;
    }

    private void Update()
    {
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);
        if (Input.GetKey(KeyCode.A) && !Lock)
        {
            Movement(-0.1f);

        }
        if (Input.GetKey(KeyCode.D) && !Lock)
        {
            Movement(0.1f);
        }
        if (Input.GetKeyDown(KeyCode.W) && !Lock)
        {
            GobekAtma();
        }
        AgirlikText.text = Agirlik + " lbs";
    }

    public void SetStart()
    {
        animator.SetBool("Start", false);
    }

    public void Movement(float x)
    {
        if (x > 0)
        {
            animator.SetBool("Right",true);
        }
        else
        {
            animator.SetBool("Left", true);
        }
        transform.position += new Vector3(x, 0, 0);
    }

    private void ForceLocation()
    {
        if (ForwardMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10), 0.5f);
            if (tmp <= transform.position.z)
            {

                animator.SetBool("Gobek", false);
                Lock = false;
                ForwardMovement = false;
                Camera.GetComponent<FollowPlayer>().Move = true;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, CharSpeed * CharSpeedMultiplier);
        ForceLocation();
    }

    public void GobekAtma()
    {
        if (this.gameObject.transform.localScale.x > 0.12f)
        {
            Agirlik -= 10;
            this.gameObject.transform.localScale -= new Vector3(KuculmeDerecesi, KuculmeDerecesi, KuculmeDerecesi);
            animator.SetBool("Gobek", true);
            Camera.GetComponent<FollowPlayer>().Lock = true;
            ForwardMovement = true;
            Lock = true;
            tmp = transform.position.z + 10;
        }
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Yemek")
        {
            other.GetComponent<AudioSource>().Play();
            Agirlik += 5; 
            this.gameObject.transform.localScale += new Vector3(BuyumeDerecesi, BuyumeDerecesi, BuyumeDerecesi);
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(other.gameObject,1f);
        }
        if (other.gameObject.tag == "Engel")
        {
            if (GetForwardMovement())
            {
                Destroy(other.gameObject);
                Destroy(Instantiate(ParcalnmýsTabak, other.gameObject.transform.position, Quaternion.identity),2f);
            }
            else
            {
                Failed.SetActive(true);
                animator.SetBool("Lock", true);
                SetSpeed(0);
                SetLock();
            }
        }
        if (other.gameObject.tag == "Death")
        {
            Failed.SetActive(true);
            animator.SetBool("Death", true);
            SetSpeed(0);
            SetLock();
        }
        if (other.gameObject.tag == "Finish")
        {
            Winner.SetActive(true);
            SetLock();
            animator.SetBool("Sevinc", true);
            SetSpeed(0);
        }
    }
}