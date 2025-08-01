using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{

    public AudioSource successSound;
    private bool hasPlayed = false;

    public void playSuccessSound()
    {
        if (!hasPlayed)
        {
            successSound.Play();
            hasPlayed = true;
        }
    }


  }
