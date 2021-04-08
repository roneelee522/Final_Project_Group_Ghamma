
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
public float damage = 10f;
public float range = 100f;
public float fireRate = 15f;

public AudioClip shootSound, reloadSound;
public AudioSource audioSource;
public float reloadTime = 1f;
private bool isReloading = false;
public Camera fpsCam;
public ParticleSystem ShotFlash;
public GameObject impactEffect;
private float nextTimeToFire = 0f;
//public Animator animator;
public int maxAmmo = 10;
public int ammo;
public TMP_Text ammoDisplay;

    void Start ()
    {
        ammo = maxAmmo;
    }
    void OnEnable ()
    {
        isReloading = false;
        //animator.SetBool("Reloading", false);
    }
    void Update()
    {
if (isReloading)
return;

    if (ammo <= 0 && Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && ammo > 0)
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
    
    IEnumerator Reload ()
    {
        isReloading = true;
        PlaySound(reloadSound);
        Debug.Log("Reloading...");
        //animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime -.25f);
        //animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        ammo = maxAmmo;
        ammoDisplay.text = ammo.ToString("");
        isReloading = false;
    }
    void Shoot ()
    {

        ShotFlash.Play();
        ammo--;
        ammoDisplay.text = ammo.ToString();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyScript target = hit.transform.GetComponent<EnemyScript>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            enemycontroller target1 = hit.transform.GetComponent<enemycontroller>();
            if (target1 != null)
            {
                target1.TakeDamage(damage);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
          Destroy(impactGO, 2f);
        }
    }
}
