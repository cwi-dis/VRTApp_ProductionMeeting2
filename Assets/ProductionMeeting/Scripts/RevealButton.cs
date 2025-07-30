using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealButton : MonoBehaviour
{
    public Vector3 realOffset = new Vector3 (0f, .5f, 0f); 
    public float speed = 1.5f;

    private Vector3 hiddenPos;
    private Vector3 revealedPos;
    private bool startMoving = false;
    private bool hasMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        hiddenPos = transform.position;
        revealedPos = hiddenPos + realOffset;
    }

    void Update()
    {
        if (startMoving && !hasMoved)
        {
            transform.position = Vector3.Lerp(transform.position, revealedPos, Time.deltaTime * speed);

            if (Vector3.Distance(transform.position, revealedPos) < 0.01f)
            {
                hasMoved = true;
            }
        }
    }

    public void Reveal()
    {
        startMoving = true;
    }
}
