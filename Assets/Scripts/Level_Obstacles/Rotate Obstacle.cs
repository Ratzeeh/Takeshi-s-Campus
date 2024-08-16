using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RotateObstacle : MonoBehaviour
{
    private ManageObstacles myManager;

    private float rotationSpeed;

    private void Awake()
    {
        myManager = GetComponentInParent<ManageObstacles>();

        rotationSpeed = myManager.setRotationSpeed;
    }


    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Simluate dying !?! : 

        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Main Menu"); // load Menu  "die"
        }
    }

}
