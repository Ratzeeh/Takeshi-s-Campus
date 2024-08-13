using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region SingletonPattern
    public static GameManager GameManagerInstance { get; private set; }

    public void Awake()
    {
        if (GameManagerInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        GameManagerInstance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
