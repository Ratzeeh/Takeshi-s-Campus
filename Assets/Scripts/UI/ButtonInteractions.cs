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
        AudioManager.Instance.PlaySound(new SoundRequest("UIButton"));
        StartCoroutine(CoCreditsClick());

    }

    public void OnPlayClick()
    {
        AudioManager.Instance.PlaySound(new SoundRequest("UIButton"));

    }

    public void OnQuitClick()
    {
        AudioManager.Instance.PlaySound(new SoundRequest("UIButton"));
        Application.Quit();
    }

    public void OnBackFromSettingsClick()
    {
        AudioManager.Instance.PlaySound(new SoundRequest("UIButton"));
        StartCoroutine(CoBackFromSettingsClick());
    }

    public void OnBackFromCreditsClick()
    {
        AudioManager.Instance.PlaySound(new SoundRequest("UIButton"));
        StartCoroutine(CoBackFromCreditsClick());
    }

    public IEnumerator CoSettingsClick()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Settings");
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public IEnumerator CoBackFromSettingsClick()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync("Settings");
    }

    public IEnumerator CoCreditsClick()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Credits");
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public IEnumerator CoBackFromCreditsClick()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("MainMenu");
        SceneManager.UnloadSceneAsync("Credits");
    }
}
