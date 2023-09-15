using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootSound;

    public float fireSpeed = 0.113f;
    public float canfire= 0.113f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > canfire)
        {
            StartCoroutine(Shoot());
            canfire = Time.time + fireSpeed;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(Shoot());
            canfire = fireSpeed;
        }
    }

    IEnumerator Shoot()
    { 
        yield return new WaitForSeconds(0.113f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        shootSound.Play();
    }
}
