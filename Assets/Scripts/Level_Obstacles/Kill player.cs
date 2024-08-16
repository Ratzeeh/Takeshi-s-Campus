using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killplayer : MonoBehaviour
{
    [SerializeField] private GameObject respawnPos;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = respawnPos.transform.position;
        }
    }
}
