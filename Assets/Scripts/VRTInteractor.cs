using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace VRT.Pilots.Common
{
    // Restored from VR2Gather (deleted with the VRTDeprecated assembly in
    // cwi-dis/VR2Gather@97b410f89), with its original .meta GUID, so the drum
    // stick tips in PFB_DrumStick keep working. See cwi-dis/VRTApp_ProductionMeeting2#23.
    /// <summary>
    /// Behaviour for an object that can interact with other objects as if it is a finger.
    /// Needs a trigger collider. On collision, it will check if the gemaObject of the other collider
    /// has a IXRActivateInteractable, and if it has it will call OnActivate() on it.
    /// Example: the drum stick colliders.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class VRTInteractor : MonoBehaviour
    {
        

        private void OnTriggerEnter(Collider other)
        {
            var otherGO = other.gameObject;
            UnityEngine.XR.Interaction.Toolkit.Interactors.IXRActivateInteractor source = null;
            UnityEngine.XR.Interaction.Toolkit.Interactables.IXRActivateInteractable target = otherGO.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.IXRActivateInteractable>(); // (IXRActivateInteractable)args.interactableObject;
            if (target == null)
            {
                return;
            }
            Debug.Log($"VRTInteractor: OnTriggerEnter from {source}, calling {target}.OnActivated() ");
            ActivateEventArgs activateArgs = new ActivateEventArgs
            {
                interactorObject = source,
                interactableObject = target
            };
            target.OnActivated(activateArgs);
        }

    }

}
