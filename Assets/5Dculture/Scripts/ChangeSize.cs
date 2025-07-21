using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public GameObject costume;
    public float Scale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateSize()
    {
        Vector3 scaleVector = new Vector3(Scale, Scale, Scale);
        costume.transform.localScale = Vector3.Scale(costume.transform.localScale, scaleVector);
    }
}



