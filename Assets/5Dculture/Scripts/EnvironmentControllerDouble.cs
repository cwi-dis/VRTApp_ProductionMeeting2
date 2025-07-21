using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnvironmentControllerDouble : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public Collider triggerZone1;
    public Collider triggerZone2;
    private bool trigger1Activated = false;
    private bool trigger2Activated = false;

    public void OnTriggerEnter(Collider other) //check ontriggerstay
    {
        Debug.Log("Hello Im here:" + other.name);

        // Check which trigger is activated based on the tag or name
        if (other == triggerZone1)
        {
            trigger1Activated = true;
            CheckAllTriggers();
            Debug.Log("Trigger 1 activated:" + trigger1Activated);
        }
        else if (other == triggerZone2)
        {
            trigger2Activated = true;
            CheckAllTriggers();
            Debug.Log("Trigger two activated:" + trigger2Activated);
        }
    }

        // Check if both triggers are activated
    private void CheckAllTriggers()
    {
        if(trigger1Activated || trigger2Activated)
        {
            videoPlayer.Play();
        }
    }


}