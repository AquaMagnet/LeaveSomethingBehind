using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool playerInput;
    Vector3 direction;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    //bool isGrounded = false;
    //public Transform groundCheck;
    //public float groundDistance = 0.4f;
    //public LayerMask groundMask;
    //public float jumpHeight = 200f;
    //bool isJumping;
   // public float gravity = 18f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (horizontal != 0f || vertical != 0f)
        {
            playerInput = true;
        }
        else
        {
            playerInput = false;
        }

       // isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

       // if (isGrounded && Input.GetAxisRaw("Jump") > 0f)
       // {
       //     isJumping = true;
       // }
       // else
       // {
       //     isJumping = false;
       // }
    }

    private void FixedUpdate()
    {
        if (playerInput)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
       // if (isJumping)
       // {
       //     //rb.AddForce(Vector3.up * gravity, ForceMode.VelocityChange);
       //
       //     Vector3 velocity = rb.velocity;
       //     velocity.y = jumpHeight;
       //     rb.velocity = velocity;
       // }


    }
}
