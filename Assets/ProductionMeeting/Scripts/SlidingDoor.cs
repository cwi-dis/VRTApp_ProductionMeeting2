using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public Vector3 leftOffset = new Vector3(0f, 0f, 1.5f);  // 왼쪽으로 1.5m 이동
    public Vector3 rightOffset = new Vector3(0f, 0f, -1.5f);  // 오른쪽으로 1.5m 이동
    public float speed = 2f;

    private Vector3 leftClosedPos;
    private Vector3 rightClosedPos;
    private Vector3 leftOpenPos;
    private Vector3 rightOpenPos;

    private bool hasOpened = false;

    void Start()
    {
        // 문 원래 위치 저장
        leftClosedPos = leftDoor.position;
        rightClosedPos = rightDoor.position;

        // 열릴 위치 계산
        leftOpenPos = leftClosedPos + leftOffset;
        rightOpenPos = rightClosedPos + rightOffset;
    }

    void Update()
    {
        if (hasOpened)
        {
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftOpenPos, Time.deltaTime * speed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightOpenPos, Time.deltaTime * speed);
        }
    }

    public void OpenDoor()
    {
        if (!hasOpened)
            hasOpened = true;
    }
}
