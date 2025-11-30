using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Multiplayer : MonoBehaviour
{
    public void SelectMultiPlayer()
    {       
        GMMScript.Instance.currentMode = GMMScript.Mode.MultiPlayer;
        SceneManager.LoadScene("TimeSelect");
    }
}