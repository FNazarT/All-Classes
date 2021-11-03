using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    private bool jumpInput;
    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump"))
        {
            jumpInput = true;
            jumpCount++;
        }
    }

    //Rigidbody movement ejecuted in FixedUpdate
    void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 movDirection = (Vector3.forward * verticalAxis + Vector3.right * horizontalAxis).normalized;

        //Para mover objetos en Unity
        //Ejemplo 1
        //transform.position += Vector3.forward * 5 * Time.deltaTime * verticalAxis;
        //transform.position += Vector3.right * 5 * Time.deltaTime * horizontalAxis;
        //transform.position += movDirection * 5 * Time.deltaTime;

        //Ejemplo 2:
        // direccion del moviento y velocidad 5 por segundo
        rb.velocity = movDirection * 5 + // En el plano
            Vector3.up * rb.velocity.y; // Velocidad con y (Gravedad)

        if (jumpInput && jumpCount <= 2)
        {
            rb.velocity = Vector3.up * 8;
        }

        jumpInput = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, Vector3.down * 1.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            jumpCount = 0;
        }
    }

    //private bool OnGround() {
    //    Debug.Log("Test");
    //    Debug.DrawRay(transform.position, Vector3.down * 1.5f, Color.black, 3);
    //    return Physics.Raycast(transform.position, Vector3.down, 1.5f);
    //}
}
