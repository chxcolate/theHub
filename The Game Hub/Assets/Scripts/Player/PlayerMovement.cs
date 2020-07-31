using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _groundDistance = 0.4f;
    private Vector3 _velocity;

    public CharacterController Controller;
    public float Gravity = -9.81f;
    public Transform GroundCheck;
    public LayerMask GroundMask;
    public float JumpForce = 10f;
    public float Speed = 12f;

    // Update is called once per frame
    public void Update()
    {
        bool isGrounded = Physics.CheckSphere(GroundCheck.position, _groundDistance, GroundMask);

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        Controller.Move(move * Speed * Time.deltaTime);

        _velocity.y += Gravity * Time.deltaTime;
        float jump = Input.GetAxis("Jump");
        if (jump == 1 && isGrounded)
        {
            _velocity.y = JumpForce * 2;
        }

        Controller.Move(_velocity * Time.deltaTime);
    }
}