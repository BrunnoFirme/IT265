using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    public float fallAcc = 2;
    public float coyoteTime = 0.5f;
    public float terminalVelocity = -120f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [Range(0,1)] public float pushablity = 0.5f;
    public float friction = 0.5f;

    float fallMult = 1;
    Vector3 velocity;
    bool isGrounded;

    private void Update()
    {
        if (!Physics.CheckSphere(groundCheck.position, groundDistance, groundMask) && isGrounded)
            StartCoroutine(CoyoteTime(coyoteTime));
        
        if (Physics.CheckSphere(groundCheck.position, groundDistance, groundMask))
            isGrounded = true;
        
        if (velocity.y < terminalVelocity)
            velocity.y = terminalVelocity;

        if (isGrounded && velocity.y <= 0 && controller.velocity.y < 1)
            velocity.y = -2f;

        if (!isGrounded && velocity.y <= 0 && controller.velocity.y < 1)
            fallMult = fallAcc;
        else
        {
            fallMult = 1;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime * fallMult;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isGrounded = false;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator CoyoteTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isGrounded = false;
    }

    public void Push(Vector3 push)
    {
        if (push.y > 0)
            velocity.y = 0;
        controller.Move(push);
    }
}