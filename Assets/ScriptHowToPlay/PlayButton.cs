using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void playButton()
    {
        if(GMMScript.Instance.currentMode == GMMScript.Mode.SinglePlayer)
        {
            SceneManager.LoadScene(3);
        }else{
            SceneManager.LoadScene(4);
        }
    }
}