using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCostume : MonoBehaviour
{
    public GameObject costume;
    public float rotateAngle;
    // Start is called before the first frame update
    
    public void rotateCostume()
    {
        costume.transform.Rotate(0.0f, rotateAngle, 0.0f);
    }
}
