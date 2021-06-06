using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int playScene = 1;

    private void Awake()
    {
        Debug.Assert(playScene > 0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(playScene);
    }

    public void OpenSettingsMenu()
    {

    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
