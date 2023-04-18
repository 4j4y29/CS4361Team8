using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveUpdated_gjm : MonoBehaviour
{
    public Rigidbody rb;
    public Transform _camera;

    public GameObject playerCamera_gjm;

    public Transform playerGroundCheck_gjm;

    public float moveSpeed = 3f;
    public float jumpForce = 10f;

    public LayerMask Ground;

    public LayerMask vehicle_gjm;

    bool isGrounded;

    void Start()
    {

    }

    void FixedUpdate()
    {

        isGrounded = Physics.CheckSphere(playerGroundCheck_gjm.position, 0.4f, Ground);

        if(isGrounded == false)
        {
            isGrounded = Physics.CheckSphere(playerGroundCheck_gjm.position, 0.4f, vehicle_gjm);
        }


        //facing direction
        Debug.DrawLine(_camera.position, transform.forward * 2.5f);

        //moving
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        //setting movement
        Vector3 move = transform.right * x + transform.forward * y;


        if (isGrounded == true)
        {
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        }
        

    }
}