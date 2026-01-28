using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCostume : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject costume;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    void Start()
    {
        originalRotation = costume.transform.localRotation;   
        originalScale = costume.transform.localScale;
    }

    public void Reset()
    {
        costume.transform.localScale = originalScale;
        costume.transform.localRotation = originalRotation;
    }
}