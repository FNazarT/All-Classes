using UnityEngine;

public class D_CameraOrbitOption1 : MonoBehaviour
{
    [SerializeField] private Transform playerPosition = default;
    [SerializeField] private Vector3 offset = Vector3.zero;
    private float rotationSpeed = 50f;

    private void Start()
    {
        transform.position = playerPosition.position + offset;
    }
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

        transform.RotateAround(playerPosition.position, Vector3.up, horizontalRotation);

        transform.Rotate(Vector3.right, verticalRotation);
        //transform.LookAt(playerPosition);
    }
}
