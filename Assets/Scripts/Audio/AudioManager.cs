using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField]
    private GameObject sfxAudioSource;
    [SerializeField]
    private AudioSource musicAudioSource;
    //[SerializeField] private Transform parentObject;

    [Header("Variables")]
    private float sfxAudioVolume;
    private float musicAudioVolume;


    private Dictionary<string, AudioData> dictionary;

    private AudioObjectPool<AudioSourceBehaviour> AudioObjectPool;

    private List<AudioSourceBehaviour> trackedObjects = new();


    #region SingletonPattern
    public static AudioManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        dictionary = new Dictionary<string, AudioData>();
        Object[] data = Resources.LoadAll("ScriptableObjects/Audio", typeof(AudioData));
        for (int i = 0; i < data.Length; i++)
        {
            dictionary.Add(data[i].name, data[i] as AudioData);
        }

        AudioObjectPool = new AudioObjectPool<AudioSourceBehaviour>(sfxAudioSource.GetComponent<AudioSourceBehaviour>(), 10, this.transform);
    }
    #endregion

    public void PlaySound(SoundRequest _soundRequest)
    {
        // AudioSource aus Pool
        var obj = AudioObjectPool.GetObject();

        // Audio Data aus Dictionary anhand request
        var requestedData = dictionary.TryGetValue(_soundRequest.name, out AudioData requestedSound);
        if (requestedData == false)
            return;

        // Audio Data auf Audio Source anwenden
        AudioSource source = obj.GetComponent<AudioSource>();
        if (source is null)
            return;

        source.clip = requestedSound.audioClips[0];
        source.volume = requestedSound.volume;
        source.spatialBlend = requestedSound.is2D ? 0 : 1;

        if (_soundRequest.name == "SpacesuitThrusters")
        {
            if (trackedObjects.Count != 0)
                return;

            trackedObjects.Add(obj);
            obj.RemoveTrace = () => trackedObjects.Remove(obj);
        }

        // Request auf Audio Source Transform anwenden
        obj.transform.position = _soundRequest.position;
        obj.transform.SetParent(_soundRequest.parentTransform);

        // Audiosource.Play();
        source.Play();

    }
}
