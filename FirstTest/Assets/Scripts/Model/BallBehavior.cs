using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    private AudioSource audio;

    private bool clickInput;
    private float _hInput;
    private Vector3 startPos;
    
    private GolfBag bag;
    private (string Name, float Power, float Lift) club;

    public LayerMask GroundLayer;
    public GameObject playerModel;
    public Vector3 playerOffset;
    public float rotateSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        audio = GetComponent<AudioSource>();

        startPos = this.transform.position;
        
        playerOffset = new Vector3(-15f, 10f, 0f);

        bag = GetComponent<GolfBag>();
        club = new ("", 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        club = bag.getClub();
        clickInput = Input.GetKeyDown(KeyCode.K);

        //rotation input/calculation
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        //Check if next shot is available
        if(isGrounded() && rb.velocity.magnitude <= 0.1f) 
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) 
            {
                club = bag.moveClub(-1);
            } 
            if (Input.GetKeyDown(KeyCode.DownArrow)) 
            {
                club = bag.moveClub(1);
            }

            startPos = this.transform.position;
            rb.MoveRotation(rb.rotation * angleRot);
            
            if (clickInput)
            { 
                audio.Play(0);
                rb.AddForce(this.transform.forward * club.Power, ForceMode.Impulse);
                rb.AddForce(Vector3.up * club.Lift, ForceMode.Impulse);
            }
            else
            {
                playerModel.transform.position = this.transform.TransformPoint(playerOffset);
                playerModel.transform.LookAt(this.transform, new Vector3(0, 1, 0));
            }
        }


    }

    void FixedUpdate()
    {
        club = bag.getClub();
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

    public bool isGrounded()
    {
        Vector3 capsuleBottom = new Vector3(col.bounds.center.x, col.bounds.min.y - 0.1f, col.bounds.center.z);
        return Physics.CheckCapsule(col.bounds.center, capsuleBottom, 0.1f, GroundLayer, QueryTriggerInteraction.Ignore);
    }
}
