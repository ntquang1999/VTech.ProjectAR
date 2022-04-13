using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 targetPosition;
    float camSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, camSpeed * Time.deltaTime);
    }
}
