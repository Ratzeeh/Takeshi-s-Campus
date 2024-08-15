using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb3D;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityForce;
    private Vector2 moveDirectionGround;

    private void Awake()
    {
        
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb3D.AddForce(-moveDirectionGround.x * moveSpeed, 0f, -moveDirectionGround.y * moveSpeed, ForceMode.Acceleration);
        
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirectionGround = context.ReadValue<Vector2>();
        }
        else
        {
            moveDirectionGround = Vector2.zero;
        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb3D.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.VelocityChange);
            
        }
    }


}
