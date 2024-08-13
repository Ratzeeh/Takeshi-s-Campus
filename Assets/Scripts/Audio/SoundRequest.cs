using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public struct SoundRequest
{
    [Header("Variables")]
    public string name;
    public Vector3 position;
    public Transform parentTransform;

    public SoundRequest(string _name, Vector3 _position, Transform _parentTransform)
    {
        name = _name;
        position = _position;
        parentTransform = _parentTransform;
    }

    public SoundRequest(string _name)
    {
        name = _name;
        position = Vector3.zero;
        parentTransform = null;
    }
}