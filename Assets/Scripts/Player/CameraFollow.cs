using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.2f;
    public Vector2 minLimit;
    public Vector2 maxLimit;

    private Vector3 offset;

    void Strat()
    {
        if (target == null) return;
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;

        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        float clampX = Mathf.Clamp(smoothPos.x, minLimit.x + cameraWidth, maxLimit.x - cameraWidth);
        float clampY = Mathf.Clamp(smoothPos.y, minLimit.y + cameraHeight, maxLimit.y - cameraHeight);

        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }
}
