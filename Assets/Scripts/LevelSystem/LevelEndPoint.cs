using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync("MainMenu");
            SceneManager.UnloadSceneAsync("Level1");
            SceneManager.UnloadSceneAsync("Level2");
            SceneManager.UnloadSceneAsync("Level3");
            SceneManager.UnloadSceneAsync("Level4");
        }
    }
}
