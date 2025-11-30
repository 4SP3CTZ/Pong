using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        if(GMMScript.Instance.currentMode == GMMScript.Mode.MultiPlayer)
        {
            Time.timeScale = 1f;  
            SceneManager.UnloadSceneAsync("EndMultiplayer");
            SceneManager.LoadScene("MultiPlayer");
        }
        else{
            Time.timeScale = 1f;  
            SceneManager.UnloadSceneAsync("EndSingle");
            SceneManager.LoadScene("SinglePlayer");
        }
    }
}