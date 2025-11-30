using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMMScript : MonoBehaviour
{
    public static GMMScript Instance;

    public enum Mode
    {
        None,
        SinglePlayer,
        MultiPlayer
    }

    public Mode currentMode = Mode.None;

    public float selectedTime;  

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}