using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceBehaviour : MonoBehaviour, IPoolable
{
    public Action Deactivate { get => m_deactivate; set { if (m_deactivate is null) m_deactivate = value; } }

    public Action RemoveTrace { get => m_removeTrace; set => m_removeTrace = value; }

    private Action m_deactivate;

    private Action m_removeTrace;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            Deactivate();

            if (RemoveTrace is not null)
                RemoveTrace();
            //audioSource.volume = 1f;
        }
    }
}
