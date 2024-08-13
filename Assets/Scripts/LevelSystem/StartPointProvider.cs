using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointProvider : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;


    private Transform m_startPointTransform;

    public Transform StartPointTransform
    {
        get => m_startPointTransform;
        set => m_startPointTransform = value;
    }

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        m_startPointTransform = this.transform;
        playerPrefab.transform.position = this.transform.position;
    }

}
