using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRMove : MonoBehaviour
{
    public GameObject myXRRig;
    public float zMoveAmount = 20f; // ī�޶� Z ��ġ ������
    public float totalTime = 5f; // ��ü �̵��� �ɸ��� �ð�
    public float targetY = 20f; // ���� ������ Y ��ġ

    private float elapsedTime = 0f; // ��� �ð�
    private Vector3 initialPosition; // �ʱ� ��ġ
    private Vector3 targetPosition; // ���� ������ ��ġ

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = myXRRig.transform.position;
        targetPosition = new Vector3(initialPosition.x, targetY, initialPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLocation()
    {
        myXRRig.transform.position = new Vector3(0, 0, 3);
    }

    public void GoToLocation2()
    {
        StartCoroutine(MoveToTargetPosition());
    }

    private IEnumerator MoveToTargetPosition()
    {
        while (elapsedTime < totalTime)
        {
            float t = elapsedTime / totalTime;
            Vector3 currentPosition = Vector3.Lerp(initialPosition, targetPosition, t);
            myXRRig.transform.position = currentPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ���� ��ġ�� �������� �� ��ġ�� ������ ����
        myXRRig.transform.position = targetPosition;
    }
}
