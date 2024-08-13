using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Audio Data", menuName = "Audio Data")]
public class AudioData : ScriptableObject
{
    [Header("Variables")]
    public AudioClip[] audioClips;
    [Range(0, 1)] public float volume;
    public bool is2D;

    public AudioData(AudioClip[] _audioClipArray, float _volume, bool _is2D)
    {
        audioClips = _audioClipArray;
        volume = _volume;
        is2D = _is2D;
    }
}