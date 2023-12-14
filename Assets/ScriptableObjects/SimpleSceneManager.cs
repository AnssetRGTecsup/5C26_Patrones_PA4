using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Simple SceneManager", menuName = "ScriptableObjects/Managers/Scene Manager", order = 0)]
public class SimpleSceneManager : ScriptableObject
{
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
