using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Vector3 targetOffset = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + targetOffset;
    }
}
