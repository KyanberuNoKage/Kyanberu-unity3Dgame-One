using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerCharacterController;
    private Transform groundCheck;

    [Header("isGrounded Settings:")]
    public float groundDistance = 1F;
    public LayerMask groundMask;
    private bool isGrounded;

    [Header("Jump Settings:")]
    public float JumpHight = 3f;

    [Header("Player Physics Settings:")]
    public float playerSpeed = 12f;
    public float gravity = -19.62f;
    private Vector3 Velocity;

    private void Start()
    {
        groundCheck = gameObject.transform.Find("GroundCheck");
        playerCharacterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        playerCharacterController.Move(move * playerSpeed * Time.deltaTime);

        Velocity.y += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHight * -2 * gravity);
        }

        playerCharacterController.Move(Velocity * Time.deltaTime);
    }
}
