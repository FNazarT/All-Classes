using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("ChangeColor");
        }
    }

    public void Shoot()
    {
        // Position
        var bullet = new GameObject();
        bullet.transform.position = transform.position;

        // Material
        var meshRenderer = bullet.AddComponent<MeshRenderer>();
        meshRenderer.material = GetComponent<MeshRenderer>().material;

        // Mesh
        var meshFilter = bullet.AddComponent<MeshFilter>();
        meshFilter.mesh = GetComponent<MeshFilter>().mesh;

        // Size
        bullet.transform.localScale = Vector3.one * 0.3f;

        // Speed
        var rb = bullet.AddComponent<Rigidbody>();
        rb.velocity = Vector3.up * 10;
    }
}
