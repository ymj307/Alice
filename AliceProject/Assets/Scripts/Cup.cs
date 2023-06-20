using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{

    public float downHeight = 0.65f;
    public float upHeight = 1.1f;
    public float movingSpeed = 1.5f;

    public GameObject pocketWatch;

    public Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * movingSpeed);

        if (pocketWatch != null) {
            pocketWatch.transform.position = new Vector3(
                transform.position.x,
                pocketWatch.transform.position.y,
                transform.position.z
            );
        };
    }

    public void MoveUp () {
        targetPosition = new Vector3 (
            transform.position.x,
            upHeight,
            transform.position.z
        );
    }

    public void MoveDown () {
        targetPosition = new Vector3 (
            transform.position.x,
            downHeight,
            transform.position.z
        );
    }
}
