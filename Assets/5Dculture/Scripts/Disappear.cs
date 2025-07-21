using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRT.Pilots.Common;

public class Disappear : NetworkCollider
{
    public GameObject redLight1;
    public GameObject redLight4;
    public GameObject redLight2;
    
    public GameObject greenLight1;
    public GameObject greenLight4;
    public GameObject greenLight2;

    public GameObject button11;
    public GameObject button12;

    public GameObject button41; 
    public GameObject button42;

    public GameObject button21;
    public GameObject button22;


    // Start is called before the first frame update
    public override void Trigger()
    {
        StartCoroutine(DisableBadObjects());
    }

    IEnumerator DisableBadObjects()
    {
        yield return new WaitForSeconds(80.0f);
        redLight1.SetActive(true);
        greenLight1.SetActive(false);
        button11.SetActive(false);
        button12.SetActive(false);

        yield return new WaitForSeconds(30.0f);
        redLight4.SetActive(true);
        greenLight4.SetActive(false);
        button41.SetActive(false);
        button42.SetActive(false);

        yield return new WaitForSeconds(30.0f);
        redLight2.SetActive(true);
        greenLight2.SetActive(false);
        button21.SetActive(false);
        button22.SetActive(false);


    }
}
