using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOption : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1f;   
        SceneManager.UnloadSceneAsync("PauseScene");
    }
    public void MainMenu()
    {
        if (GMMScript.Instance != null)
        Destroy(GMMScript.Instance.gameObject);

        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.scene.name == "DontDestroyOnLoad")
            Destroy(obj);
        }
        Time.timeScale = 1f;

        Scene pauseScene = SceneManager.GetSceneByName("PauseScene");
        if (pauseScene.isLoaded)
        {
            SceneManager.UnloadSceneAsync("PauseScene");
        }

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
