using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZMove : MonoBehaviour
{
    public float zMoveAmount = 20f; // ī�޶� Z ��ġ ������

    public void OnButtonClick()
    {
        // ���� ī�޶��� ��ġ�� ������
        Vector3 currentPosition = transform.position;

        // Z ��ġ�� ������Ŵ
        currentPosition.z += zMoveAmount;

        // ����� ��ġ�� �����Ͽ� ī�޶� �̵���Ŵ
        transform.position = currentPosition;
    }
}
