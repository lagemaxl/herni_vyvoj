using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float sensitivity = 1;

    private Vector2 rot;

    [SerializeField]
    private bool dump;

    [SerializeField]
    private float runMult = 3f;

    [SerializeField]
    private float stamina = 100f;

    [SerializeField]
    private Transform groundChecker;

    [SerializeField]
    private Transform cameraHolder;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    void MouseRotate()
    {
        rot.x += Input.GetAxis("Mouse X") * sensitivity;
        rot.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.rotation = Quaternion.Euler(0, rot.x, 0);
        cameraHolder.localRotation = Quaternion.Euler(-rot.y, 0, 0);
    }

    void MakeMove()
    {


        var forward = Input.GetAxisRaw("Vertical");
        var sides = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }

        Vector3 localVelocity = Vector3.ClampMagnitude(
            new Vector3(sides, 0, forward), 1)
            * speed * Time.deltaTime;
        var transformed = transform.TransformDirection(localVelocity);

        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0 && transformed.sqrMagnitude > 0)
        {
            transformed *= runMult;
            stamina -= Time.deltaTime;
        } 

        if(!Input.GetKey(KeyCode.LeftShift) && stamina < 100) // pokud nebìžim 
        {
            stamina += Time.deltaTime;
        }

        rb.velocity = new Vector3(transformed.x, rb.velocity.y, transformed.z);


        if (dump)
        {
            if (rb.velocity.sqrMagnitude < 0.01f)
                rb.velocity = Vector3.zero;
        }
    }

    void CheckGrounded()
    {
        //Debug.DrawRay(groundChecker.position, Vector3.down * 0.1f, Color.red);
        if(Physics.Raycast(groundChecker.position, Vector3.down, out RaycastHit hit, 0.1f))
        {
            isGrounded = true;
            hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            //Debug.Log(hit.collider.name);
        } else
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        CheckGrounded();
        MakeMove();
        MouseRotate();
        /*
        1) Pohyb ve smìru hráèe
        2) Otáèení hráèe podle myši
        3) Promìnná sensitivity
        4) Lock pozice myši a schování
         */
    }
}
