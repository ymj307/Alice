using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZMove : MonoBehaviour
{
    public float zMoveAmount = 20f; // 카메라 Z 위치 증가량

    public void OnButtonClick()
    {
        // 현재 카메라의 위치를 가져옴
        Vector3 currentPosition = transform.position;

        // Z 위치를 증가시킴
        currentPosition.z += zMoveAmount;

        // 변경된 위치를 적용하여 카메라를 이동시킴
        transform.position = currentPosition;
    }
}
