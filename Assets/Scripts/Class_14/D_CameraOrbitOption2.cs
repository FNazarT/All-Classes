using UnityEngine;

public class D_CameraOrbitOption2 : MonoBehaviour
{
    [SerializeField] private Transform playerPosition = default;
    [SerializeField] private Vector3 offset = Vector3.zero;
    private float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        OrbitAroundPlayer();
    }

    void OrbitAroundPlayer()
    {
        float rotationAxisX = Input.GetAxis("Mouse X");
        float rotationAxisY = Input.GetAxis("Mouse Y");

        float horizontalRotation = rotationAxisX * rotationSpeed * Time.deltaTime;
        float verticalRotation = rotationAxisY * rotationSpeed * Time.deltaTime * -1f;

        offset = Quaternion.AngleAxis(horizontalRotation, Vector3.up) * offset;

        transform.position = playerPosition.position + offset;

        transform.LookAt(playerPosition);
    }
}
