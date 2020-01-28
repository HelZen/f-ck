using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class mainMenu : MonoBehaviour
{

    void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExecuteMenuItem("Edit/Play");
        }
        else
        {
            Application.Quit();
        }
    }

}