using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        // Look at
        //Vector3 direction = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(direction, new Vector3(1, 1, 0));
        //transform.LookAt(target);
        //transform.right = direction;

        // Q * Q = suma rotaciones
        //transform.rotation = transform.rotation * Quaternion.Euler(0, 45 * Time.deltaTime, 0);

        // Q * V = V rotado
        //Quaternion targetRotation = Quaternion.LookRotation(direction, new Vector3(1, 1, 0));
        //transform.right = targetRotation * Vector3.forward;

        // Movimiento suave
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);

        // Observe y lo siga
        //transform.Translate(2 * Time.deltaTime, 0, 0);
        //transform.LookAt(target);
        //transform.position = target.position - transform.forward;
    }
}