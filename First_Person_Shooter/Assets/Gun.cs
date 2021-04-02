﻿
using UnityEngine;

public class Gun : MonoBehaviour
{
public float damage = 10f;
public float range = 100f;
public float fireRate = 15f;

public AudioClip shootSound;
public AudioSource audioSource;
    public Camera fpsCam;
public ParticleSystem ShotFlash;
public GameObject impactEffect;
private float nextTimeToFire = 0f;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            PlaySound(shootSound);
            Shoot();
        }
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    void Shoot ()
    {

        ShotFlash.Play();        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyScript target = hit.transform.GetComponent<EnemyScript>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
         
          GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
          Destroy(impactGO, 2f);
        }
    }
}
