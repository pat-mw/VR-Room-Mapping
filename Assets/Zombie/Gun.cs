using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float gunForce = 1f;
    [SerializeField] private Transform gunTip;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = gunTip.position;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * gunForce, ForceMode.Impulse);
    }
}
