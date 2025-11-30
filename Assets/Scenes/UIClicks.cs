using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClicks : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip uiclicks;

    public void Audio(){
        audioSource.PlayOneShot(uiclicks);
    }
}
