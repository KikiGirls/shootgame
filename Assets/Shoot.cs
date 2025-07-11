using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float fireRate = 0.15f;
    private float effctsDisplayTime = 0.2f;
    private float nextTimeToFire = 0f;
    AudioSource audioSource;
    Light lightSource;
    ParticleSystem particleSystem;
    LineRenderer lineRenderer;


    private Ray shootRey;
    private bool isShoot;

    private int shootMask;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        lightSource = GetComponent<Light>();
        particleSystem = GetComponent<ParticleSystem>();
        lineRenderer = GetComponent<LineRenderer>();
        shootMask = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canfire())
        {
            shoot();
            Invoke("afterShoot", fireRate * effctsDisplayTime);
        }
    }

    private bool canfire()
    {
        return Time.time >= nextTimeToFire;
    }

    private void afterShoot()
    {
        lightSource.enabled = false;
        lineRenderer.enabled = false;
    }

    void shoot()
    {
        // 开枪英语
        audioSource.Play();
        
        // 开枪火焰
        lightSource.enabled = true;
        
        particleSystem.Play();
        
        lineRenderer.SetPosition(0, transform.position);
        
        lineRenderer.enabled = true;

        nextTimeToFire = Time.time + fireRate;
        
        shootRey.origin = transform.position;
        shootRey.direction = transform.forward;
        
        RaycastHit shootHit;
        if (Physics.Raycast(shootRey, out shootHit, 100, shootMask))
        {
            lineRenderer.SetPosition(1, shootHit.point);

            Enemymanager em = shootHit.collider.gameObject.GetComponent<Enemymanager>();
            em.hit(shootHit);
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + transform.forward *100);
        }
        
    }
}
