using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public void OpenPauseMenu()
    {
        Time.timeScale = 0f;  
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
    }
}
