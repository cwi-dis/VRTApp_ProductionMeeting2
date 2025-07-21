using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRT.Pilots.Common;

public class NetworkCollider : NetworkTrigger
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Trigger();
    }
}
