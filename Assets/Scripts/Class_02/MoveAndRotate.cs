using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    private float h;
    [SerializeField] private float speed = 0;
    private RaycastHit hitInfo;
    private Rigidbody rb;
    private Vector3 yPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");

        //transform.Translate(new Vector3(h * speed * Time.deltaTime, 0f, 0f));

        rb.velocity = transform.right * speed * h;
        
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo))
        {
            // Roto segun inclinacion piso
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.5f);

            // Me ubico arriba del piso a cierta distancia
            //transform.position = hitInfo.point + hitInfo.normal;
        }
    }
}
