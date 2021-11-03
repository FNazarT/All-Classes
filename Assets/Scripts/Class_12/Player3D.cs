using UnityEngine;

public class Player3D : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        int hRaw = (int) Input.GetAxisRaw("Horizontal");
        int vRaw = (int) Input.GetAxisRaw("Vertical");
        bool moving = hRaw != 0 || vRaw != 0;

        if (moving)
        {
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = Camera.main.transform.right;

            Vector3 dir = forward * v + right * h;

            transform.forward = Vector3.Lerp(transform.forward, dir, 0.3f);

            //Resident Evil movement
            //transform.Rotate(0, 120 * Time.deltaTime * h, 0);
        }
        animator.SetBool("Moving", moving);

        //Resident Evil Movement
        //animator.SetBool("Moving", v > 0);

        float crouch = Input.GetAxis("Crouch");
        animator.SetFloat("Crouch", crouch);

        bool opening = Input.GetButtonDown("Opening");
        animator.SetBool("Opening", opening);
    }
}
