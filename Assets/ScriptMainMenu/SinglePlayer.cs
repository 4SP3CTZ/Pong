using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayer : MonoBehaviour
{
    public void SelectSinglePlayer()
    {
        GMMScript.Instance.currentMode = GMMScript.Mode.SinglePlayer;
        SceneManager.LoadScene(1);
    }
}