using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptFinishedMulti : MonoBehaviour
{
    public Image winnerImage;               
    public Sprite player1WinSprite;
    public Sprite player2WinSprite;

    void Start()
    {
        string result = GameManager.Instance.endResult;

        if (result == "p1")
        {
            winnerImage.sprite = player1WinSprite;
        }
        else if(result == "p2")
        {
            winnerImage.sprite = player2WinSprite;
        }
    }
}
