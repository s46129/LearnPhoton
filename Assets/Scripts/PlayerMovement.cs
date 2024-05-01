using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PlayerMovement : NetworkBehaviour
{
    [Inject] private CharacterController _characterController;
    public float playerSpeed = 5f;

    public override void FixedUpdateNetwork()
    {
        if (!HasInputAuthority)
        {
            return;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(move);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}