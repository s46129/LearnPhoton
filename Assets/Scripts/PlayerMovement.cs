using System;
using Fusion;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : NetworkBehaviour
{
    [Inject] private CharacterController _characterController;
    public float playerSpeed = 5f;

    public bool jumpPressed;
    private Vector3 _velocity;
    public float GravityValue = -9.81f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }


    public override void FixedUpdateNetwork()
    {
        Debug.Log($"Authority: {HasInputAuthority}");
        if (HasInputAuthority == false)
        {
            return;
        }

        if (_characterController.isGrounded)
        {
            _velocity = new Vector3(0, -1, 0);
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Runner.DeltaTime *
                       playerSpeed;
        _velocity.y += GravityValue * Runner.DeltaTime;
        if (jumpPressed && _characterController.isGrounded) ;
        {
            _velocity.y += JumpForce;
        }

        _characterController.Move(move + _velocity * Runner.DeltaTime);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    public float JumpForce;
}