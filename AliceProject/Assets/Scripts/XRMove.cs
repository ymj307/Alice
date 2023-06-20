using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRMove : MonoBehaviour
{
    public GameObject myXRRig;
    public float zMoveAmount = 20f; // 카메라 Z 위치 증가량
    public float totalTime = 5f; // 전체 이동에 걸리는 시간
    public float targetY = 20f; // 최종 도달할 Y 위치

    public float zMoveAmount2 = 20f; // 카메라 Z 위치 증가량
    public float targetY2 = 0f; // 최종 도달할 Y 위치

    private float elapsedTime = 0f; // 경과 시간
    private Vector3 initialPosition; // 초기 위치
    private Vector3 targetPosition; // 최종 도달할 위치
    private Vector3 targetPosition2;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = myXRRig.transform.position;
        targetPosition = new Vector3(initialPosition.x, targetY, initialPosition.z);
        targetPosition2 = new Vector3(initialPosition.x, targetY2, initialPosition.z); // targetY2로 변경
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

        // 최종 위치에 도달했을 때 위치를 강제로 보정
        myXRRig.transform.position = targetPosition;
    }

    public void GoToLocationDecrease()
    {
        StartCoroutine(MoveToTargetPositionDecrease());
    }

    private IEnumerator MoveToTargetPositionDecrease()
    {
        elapsedTime = totalTime; // 초기값을 totalTime으로 설정

        while (elapsedTime > 0)
        {
            float t = elapsedTime / totalTime;
            Vector3 currentPosition = Vector3.Lerp(initialPosition, targetPosition2, t);
            myXRRig.transform.position = currentPosition;

            elapsedTime -= Time.deltaTime;
            yield return null;
        }

        // 최종 위치에 도달했을 때 위치를 강제로 보정
        myXRRig.transform.position = targetPosition2;
    }
}

