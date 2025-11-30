using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeSelection : MonoBehaviour
{
    public void aMin(){
        GMMScript.Instance.selectedTime = 60f;
        SceneManager.LoadScene(2);
    }
    public void threeMin(){
        GMMScript.Instance.selectedTime = 180f;
        SceneManager.LoadScene(2);
    }
    public void fiveMin(){
        GMMScript.Instance.selectedTime = 300f;
        SceneManager.LoadScene(2);
    }
}
