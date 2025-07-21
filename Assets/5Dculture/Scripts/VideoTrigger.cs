using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.Collections.Specialized;

public class VideoTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Drag the Video Player component to this field in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Make sure your player GameObject has the tag "Player"
        {
            videoPlayer.Play();  // Play the video
        }
    }
}