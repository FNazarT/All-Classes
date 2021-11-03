using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraOrbitAutoRotation : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;
    public float distanceFromTarget = 10;
    public Vector2 rotationSpeed;

    Vector3 targetPosition { get { return target.transform.position + targetOffset; } }
    Vector3 rotationVector;

    void LateUpdate()
    {
        HandleInput();
        OrbitCamera(targetPosition, rotationVector);
    }

    void HandleInput()
    {
        rotationVector.x = Time.deltaTime * rotationSpeed.x;
        rotationVector.y = Time.deltaTime * rotationSpeed.y;
    }

    public void OrbitCamera(Vector3 target, Vector2 rotationSpeed)
    {
        transform.RotateAround(targetPosition, Vector3.up, rotationSpeed.x);
        transform.RotateAround(targetPosition, Vector3.right, rotationSpeed.y);
        this.transform.eulerAngles -= this.transform.eulerAngles.z * Vector3.forward;
        transform.position = target - this.transform.rotation * (Vector3.forward * distanceFromTarget);
    }

    void OnDrawGizmos()
    {   // Draw target position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(targetPosition, 0.1f);
    }
}
