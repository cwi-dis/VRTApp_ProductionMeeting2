using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using VRT.Pilots.Common;

public class TriggerIf : NetworkTrigger
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;

    public override void Trigger()
    {
        if (!object1.activeSelf && !object2.activeSelf && object3.activeSelf && !object4.activeSelf)
        {
            base.Trigger(); // Call the base Trigger method
            return;
        }
    }
}
