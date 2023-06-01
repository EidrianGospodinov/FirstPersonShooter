using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    [Range(6f, 20f)]
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    [Range(0f, 20f)]
    public float jumpStrenght = 2f;

    public bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;//layer mask is for the layers its next to the tags on top right


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //makes the ground process smoother
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");


        Vector3 move = transform.right * movementX + transform.forward * movementZ;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpStrenght * -2f * gravity);
        }
    }
}
