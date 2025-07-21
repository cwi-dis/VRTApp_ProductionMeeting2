using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public GameObject costume;
    public float Scale = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateSize()
    {
        costume.transform.localScale += new Vector3(Scale, Scale, Scale);
    }
}
