using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    bool LeftMovement;
    bool RightMovement;
    bool ForwardMovement;

    Rigidbody rb;
    [SerializeField]
    stage currentstage;

    public Transform MidLoc;
    public Transform LeftLoc;
    public Transform RightLoc;

    float timeLimit;
    float pastTime;

    public float CharSpeed;
    public float CharSpeedMultiplier;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentstage = stage.mid;
        timeLimit = 10;
        pastTime = 0;
        LeftMovement = false;
        Lock = false;
        RightMovement = false;
    }

    public bool GetForwardMovement()
    {
        return ForwardMovement;
    }

    public void SetLock()
    {
        Lock = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !Lock)
        {
            switch (currentstage)
            {
                case stage.mid:
                    LeftMovement = true;
                    Lock = true;
                    tmp = LeftLoc.position.x;
                    currentstage = stage.left;
                    break;
                case stage.left:
                    break;
                case stage.right:
                    LeftMovement = true;
                    Lock = true;
                    tmp = LeftLoc.position.x;
                    currentstage = stage.mid;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && !Lock)
        {
            switch (currentstage)
            {
                case stage.mid:
                    RightMovement = true;
                    Lock = true;
                    tmp = RightLoc.position.x;
                    currentstage = stage.right;
                    break;
                case stage.right:
                    break;
                case stage.left:
                    RightMovement = true;
                    Lock = true;
                    tmp = RightLoc.position.x;
                    currentstage = stage.mid;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GobekAtma();
        }
        ForceLocation();
    }

    private void ForceLocation()
    {
        if (LeftMovement)
        {
            
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(tmp,LeftLoc.position.y,LeftLoc.position.z),0.1f);
            if (tmp == transform.position.x)
            {
                Lock = false;
                LeftMovement = false;
            }
        }
        if (RightMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(tmp, RightLoc.position.y, RightLoc.position.z), 0.1f);
            if (tmp == transform.position.x)
            {
                Lock = false;
                RightMovement = false;
            }
        }
        if (ForwardMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z+10), 0.1f);
            if (tmp <= transform.position.z)
            {
                Lock = false;
                ForwardMovement = false;
                Camera.GetComponent<FollowPlayer>().Move = true ;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Time.fixedTime - pastTime > timeLimit)
        {
            pastTime = Time.fixedTime;
            //CharSpeedMultiplier = pastTime / 500;
        }
        transform.position += new Vector3(0, 0, CharSpeed * CharSpeedMultiplier);
        
    }

    public void GobekAtma()
    {
        Camera.GetComponent<FollowPlayer>().Lock = true;
        ForwardMovement = true;
        Lock = true;
        tmp = transform.position.z + 10;
    }
}