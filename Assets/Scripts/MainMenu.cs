using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Loading_Screen");
    }

    public void QuitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}
