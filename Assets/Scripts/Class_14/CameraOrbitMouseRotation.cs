using UnityEngine;

[ExecuteInEditMode]
public class CameraOrbitMouseRotation : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;
    public float distanceFromTarget = 10;
    public float rotationSpeed = 20f;
    public float zoomSpeed = 10f;
    public Vector2 rotationVector;

    Vector3 targetPosition { get { return target.position + targetOffset; } }

    void LateUpdate()
    {
        if (Application.isPlaying)
        {
            HandleInput();
        }
        OrbitCamera(targetPosition, rotationVector);
    }

    void HandleInput()
    {
        distanceFromTarget += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        rotationVector.x += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        rotationVector.y += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime * -1f; // invert y axis
    }

    void OrbitCamera(Vector3 target, Vector2 rotationVector)
    {
        Quaternion rotation = Quaternion.Euler(rotationVector.y, rotationVector.x, 0);
        transform.position = target - rotation * (Vector3.forward * distanceFromTarget);
        transform.rotation = rotation;
    }
}
