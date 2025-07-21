using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using VRT.Pilots.Common;

public class TriggerIfCorrect : NetworkTrigger
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject objectbad1;
    public GameObject objectbad2;
    public GameObject objectbad3;
    public GameObject objectbad4;
    //public XRBaseInteractor interactor;

    /* protected override void Awake()
     {
         base.Awake();
     }*/

    /*private void OnTriggerEnter(XRBaseInteractor interactor)
    {
        if (object1.activeSelf && object2.activeSelf && object3.activeSelf && object4.activeSelf)
        {
            Trigger(); // Use the inherited Trigger method
        }
    }*/

    public override void Trigger()
    {
        if (object1.activeSelf && object2.activeSelf && object3.activeSelf && object4.activeSelf)
        {
            base.Trigger(); // Call the base Trigger method
            return;
        }
        if (!object1.activeSelf)
        {
            objectbad1.SetActive(true);
        }
        if (!object2.activeSelf)
        {
            objectbad2.SetActive(true);
        }
        if (!object3.activeSelf)
        {
            objectbad3.SetActive(true);
        }
        if (!object4.activeSelf)
        {
            objectbad4.SetActive(true);
        }
        StartCoroutine(DisableBadObjects());
    }

    IEnumerator DisableBadObjects()
    {
        yield return new WaitForSeconds(2.0f);
        objectbad1.SetActive(false);
        objectbad2.SetActive(false);
        objectbad3.SetActive(false);
        objectbad4.SetActive(false);
    }
}
