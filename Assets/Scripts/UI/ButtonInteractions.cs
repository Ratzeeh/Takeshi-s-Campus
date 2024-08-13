using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteractions : MonoBehaviour
{
    private enum E_Scenes
    {
        FINAL = 0,
        Credits = 1, 
        MainMenu = 2,
        Settings = 3,
        IngameUI = 4,
    }

    public void OnSettingsClick()
    {
        AudioManager.Instance.PlaySound(new SoundRequest("UIButton"));
        StartCoroutine(CoSettingsClick());
    }

    public void OnCreditsClick()
    {

    }

    public void OnPlayClick()
    {

    }

    public void OnQuitClick()
    {

    }

    public void OnBackFromSettingsClick()
    {

    }

    public void OnBackFromCreditsClick()
    {

    }

    public IEnumerator CoSettingsClick()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Settings");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
