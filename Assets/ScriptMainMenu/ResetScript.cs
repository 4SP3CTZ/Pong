using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 1f;

        GameManager.Instance = null;
        GMMScript.Instance = null;

    }

}
