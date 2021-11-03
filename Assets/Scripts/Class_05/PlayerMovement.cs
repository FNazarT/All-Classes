using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Transform camTransform = null;
    [SerializeField] private Transform weaponTransform = null;

    new public Transform transform { get; private set; }
    

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        MoveCharacter();
        RotateCharacter();
    }

    void MoveCharacter()
    {
        float yMovement = Input.GetAxis("Vertical");
        transform.localPosition += transform.forward * yMovement * movementSpeed * Time.deltaTime;

        float xMovement = Input.GetAxis("Horizontal");
        transform.localPosition += transform.right * xMovement * movementSpeed * Time.deltaTime;
    }

    void RotateCharacter()
    {
        float rotateX = Input.GetAxis("Mouse X");
        float rotateY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, rotateX * rotationSpeed * Time.deltaTime);
        camTransform.Rotate(Vector3.right, -rotateY * rotationSpeed * Time.deltaTime);
        weaponTransform.Rotate(Vector3.right, -rotateY * rotationSpeed * Time.deltaTime);
    }
}
