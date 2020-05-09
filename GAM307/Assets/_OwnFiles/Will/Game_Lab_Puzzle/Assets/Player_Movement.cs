using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float sensitivity = 150f;

    public Camera playerCam;

    private float xRotation;

    Rigidbody rb;
    CapsuleCollider col;
    float colY;

    public float playerSpeed = 5f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        colY = col.height;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(value: xRotation, min: -90, max: 90);

        playerCam.transform.localRotation = Quaternion.Euler(xRotation, y: 0, z: 0);
        transform.Rotate(Vector3.up * mouseX);

        /*if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCrouch();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            StopCrouch();
        }*/
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            //rb.AddRelativeForce(new Vector3(h, rb.velocity.y, v) * playerSpeed, ForceMode.VelocityChange);

            rb.velocity = transform.rotation * new Vector3(h, 0, v) * playerSpeed + new Vector3(0, rb.velocity.y, 0);
    }

    /*private void StartCrouch()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        col.height = colY * .2F;
    }

    private void StopCrouch()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        col.height = colY;
        transform.localScale = new Vector3(x: 1, y: 1, z: 1);
    }*/
}
