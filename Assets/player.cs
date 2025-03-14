using System;

using UnityEngine;


public class FPSPlayer : MonoBehaviour
{

    int moveSpeed = 4;
    float lookSpeedX = 6;   //left/right mouse sensitivity
    float lookSpeedY = 3; // up/down mouse sensitivity
    int JumpForce = 300;
    public LayerMask groundLayer;
    public Transform feetTrans;
    float groundCheckDist = .5f;
    public bool grounded = false;

    Transform camTrans;
    float xRotation;
    float yRotation;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camTrans = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked; //hide the mouse and lock it center to the screen

        rb = GetComponent<Rigidbody>();

       
    }

    void FixedUpdate()
    {
        Vector3 moveDir = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxis("Horizontal");
        moveDir *= moveSpeed;
        moveDir.y = rb.linearVelocity.y;
        rb.linearVelocity = moveDir;


        grounded = Physics.CheckSphere(feetTrans.position, groundCheckDist, groundLayer);

    }

    // Update is called once per frame
    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSpeedX;
        xRotation -= Input.GetAxis("Mouse Y") * lookSpeedY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        camTrans.localEulerAngles = new Vector3(xRotation, 0, 0);
        transform.eulerAngles = new Vector3(0, yRotation, 0);

        if(grounded && Input.GetButtonDown("Jump")) {
            rb.AddForce(new Vector3(0, JumpForce, 0));
        }
    }

    private object newVector3(int v1, int jumpForce, int v2)
    {
        throw new NotImplementedException();
    }
}