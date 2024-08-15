using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 lookVec2 = Vector2.zero;

    [Header("Settings Camera")]
    [SerializeField]
    public float cameraSensitivity;

    private void LateUpdate()
    {
        //Rotate(InputController.cameraRotation * cameraSensitivity * Time.deltaTime);
    }


    public void Rotate(Vector2 rotation)
    {
        lookVec2.x += rotation.x;
        lookVec2.y -= rotation.y;
        transform.rotation = Quaternion.Euler(Mathf.Clamp(lookVec2.y, -50f, 50f), lookVec2.x, 0f);
    }
}
