using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform target;  // o player
    [SerializeField] private Vector3 offset = new Vector3(0f,0f,-10f);    // distância entre câmera e player
	[SerializeField] private float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

