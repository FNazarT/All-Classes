using UnityEngine;

public class SimpleWeaponController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform spawnPoint = null;
    [SerializeField] float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab);

            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;

            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

            bulletRB.velocity = bullet.transform.forward * bulletSpeed;
        }
    }
}
