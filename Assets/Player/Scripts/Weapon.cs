using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootSound;

    public float fireSpeed = 0.113f;
    public float canfire = 0f;
    // Update is called once per frame  
    void Update()
    {
        if(Time.time >= canfire)
        {
            if(Input.GetButton("Fire1"))
            {
                Shoot();
                canfire = Time.time + fireSpeed;
            }
        }
    }

    void Shoot()
    { 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        shootSound.Play();
    }
}
