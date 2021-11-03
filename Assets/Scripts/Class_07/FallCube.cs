using UnityEngine;

public class FallCube : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private GameObject Cube = null;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Rigidbody cubeRB = Cube.GetComponent<Rigidbody>();
            cubeRB.isKinematic = false;
            cubeRB.velocity = Vector3.down * fallSpeed;
        }
    }
}
