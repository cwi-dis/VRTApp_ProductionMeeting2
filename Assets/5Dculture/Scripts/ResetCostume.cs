using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCostume : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject costume;
    private Quaternion originalRotation;
    void Start()
    {
        originalRotation = costume.transform.localRotation;   
    }

    public void Reset()
    {
        costume.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        costume.transform.localRotation = originalRotation;
    }
}
