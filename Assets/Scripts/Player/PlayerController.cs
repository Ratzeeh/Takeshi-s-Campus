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
    [SerializeField] private float minVelocity;
    [SerializeField] private float maxVelocity;


    [SerializeField] public float globalGravity = -9.81f;
    [SerializeField] public float gravityScale = 1.0f;

    private void Awake()
    {

    }

    private void Update()
    {
        Debug.Log(rb3D.velocity);
    }

    private void FixedUpdate()
    {
        rb3D.AddForce(moveDirectionGround.x * moveSpeed, 0f, moveDirectionGround.y * moveSpeed, ForceMode.Acceleration);

        if (new Vector3(rb3D.velocity.x, 0, rb3D.velocity.z).magnitude > maxVelocity)
        {
            Vector3 newSpeed = Vector3.Normalize(rb3D.velocity) * maxVelocity;
            rb3D.velocity = new Vector3(newSpeed.x, rb3D.velocity.y, newSpeed.z);
        }

        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb3D.AddForce(gravity, ForceMode.Acceleration);

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
