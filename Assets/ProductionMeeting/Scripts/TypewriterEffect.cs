using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshPro textMesh;
    public string fullText = "Congratulations!\n\nYou are ready to move on!";
    public float delay = 0.05f;

    private void OnEnable()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        textMesh.text = "";
        foreach (char c in fullText)
        {
            textMesh.text += c;
            yield return new WaitForSeconds(delay);
        }
    }
}

