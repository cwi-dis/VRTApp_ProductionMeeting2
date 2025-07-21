using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisabeCostumeMeshRenderer : MonoBehaviour
{
    public GameObject costume;
    // Start is called before the first frame update
    private void Awake()
    {
        //diable the costume in the museum scene
        if (SceneManager.GetActiveScene().name == "MediaScape2") {
            costume.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
        
    }

   
}
