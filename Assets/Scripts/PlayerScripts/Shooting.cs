﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject theBullet;
    public GameObject top;

    public int bulletSpeed;
    public float despawnTime = 3.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (shootAble)
            {
                shootAble = false;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        shootAble = true;
    }
    void Shoot()
    {
       Quaternion rot = top.transform.rotation;
        float angle = 90 * Mathf.Deg2Rad;

        rot.Set(rot.x, rot.y, angle, 1);
        var bullet = Instantiate(theBullet, transform.position, rot);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
       // Physics.IgnoreCollision(bullet.GetComponent<Collider>(), this.GetComponent<Collider>());
        //Physics.IgnoreLayerCollision(9, 8);

        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

       // Destroy(bullet, despawnTime);
        

    }
}
