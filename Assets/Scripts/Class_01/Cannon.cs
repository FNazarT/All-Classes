using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject CannonBall;
    public Transform ShootingPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(verticalInput * 45 * Time.deltaTime, 0, -horizontalInput * 45 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject cannonBall = Instantiate(CannonBall);
            cannonBall.transform.position = ShootingPoint.position;

            Rigidbody cannonBallRb = cannonBall.GetComponent<Rigidbody>();
            cannonBallRb.velocity = transform.up * 7;
        }
    }
}
