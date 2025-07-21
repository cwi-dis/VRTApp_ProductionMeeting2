using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnvironmentController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void OnTriggerEnter(Collider other)
    {
        videoPlayer.Play();
        
    }
}