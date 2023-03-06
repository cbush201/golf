using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    private Vector3 startPos;
    private GolfBag bag;
    private Club club;
    private bool clickInput;
    private float _hInput;
    private bool locked;

    public LayerMask GroundLayer;
    public float rotateSpeed;
    public GameObject playerModel;
    public Vector3 playerOffset;


    //on Start
    void Start()
    {
        locked = true;
        playerOffset = new Vector3(-15f, 10f, 0f);
        bag = new GolfBag();
        club = bag.getClub();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        clickInput = Input.GetKeyDown(KeyCode.K);

        //rotation input/calculation
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        //Change between clubs
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            club = bag.moveUpClub();
        } 
        else if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            club = bag.moveDownClub();
        }


        //Check if next shot is available
        if(isGrounded() && rb.velocity.magnitude <= 0.1f) 
        {
            startPos = this.transform.position;
            rb.MoveRotation(rb.rotation * angleRot);

            // if(this.transform.position + playerOffset != startPos + playerOffset)
            // {
            //     playerModel.transform.position = this.transform.position + playerOffset;
            // }
            
            if (clickInput)
            {
                //playerModel.GetComponent<Animator>().SetBool("hasSwung", true);
                // if (!locked)
                // {
                    
                // }
                
                rb.AddForce(this.transform.forward * club.getPower(), ForceMode.Impulse);
                rb.AddForce(Vector3.up * club.getLift(), ForceMode.Impulse);
                locked = true;
            }
            else
            {
                playerModel.transform.position = this.transform.TransformPoint(playerOffset);
                playerModel.transform.LookAt(this.transform, new Vector3(0, 1, 0));
            }
        }


    }

    public void Swing()
    {
        locked = false;
    }

    public Vector3 getStartPos()
    {
        return startPos;
    }

    public void setPos(Vector3 newPos)
    {
        this.transform.position = newPos;
        rb.velocity = new Vector3(0, 0, 0);
    }

    private bool isGrounded()
    {
        Vector3 capsuleBottom = new Vector3( col.bounds.center.x, col.bounds.min.y - 0.1f, col.bounds.center.z);
        return Physics.CheckCapsule(col.bounds.center, capsuleBottom, 0.1f, GroundLayer, QueryTriggerInteraction.Ignore);
    }
}
