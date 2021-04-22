using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    public int pistolAmmo;
    public int pistolinvAmmo;

      public int machineAmmo;
    public int machineinvAmmo;
public Weapon_Switcher script;
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
public Animator animator;
public int maxmagAmmo = 35;
public int ammo;
public TMP_Text currentAmmoText;
public TMP_Text invAmmoText;

    void Start ()

    {
        fpsCam = GameObject.Find("Player/Main Camera").GetComponent<Camera>();
        currentAmmoText = GameObject.Find("Ammo Text").GetComponent<TMP_Text>();

invAmmoText = GameObject.Find("Ammo Text Static").GetComponent<TMP_Text>();
        ammo = maxmagAmmo;
machineinvAmmo = 70;


    

    }
    void OnEnable ()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    void Update()
    {
if (isReloading)
return;
if (script.selectedWeapon == 0)
{
    currentAmmoText.text = pistolAmmo.ToString ();
    invAmmoText.text = pistolinvAmmo.ToString ();

}

if (script.selectedWeapon == 1)
{
    currentAmmoText.text = machineAmmo.ToString ();
    invAmmoText.text = machineinvAmmo.ToString ();

}

 if (Input.GetKey(KeyCode.R) && script.selectedWeapon == 0 && pistolinvAmmo > 0)
        {
            StartCoroutine(Reloadpistol());
            return;
        }
        if (Input.GetKey(KeyCode.R) && script.selectedWeapon == 1 && machineinvAmmo > 0)
        {
            StartCoroutine(Reloadmachine());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && ammo > 0 && script.selectedWeapon == 0)
        {
            pistolAmmo --;
            nextTimeToFire = Time.time + 1f/fireRate;
            PlaySound(shootSound);
            Shootpistol();
        }
          if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && ammo > 0 && script.selectedWeapon == 1)
        {
            machineAmmo --;
            nextTimeToFire = Time.time + 1f/fireRate;
            PlaySound(shootSound);
            Shootmachine();
        }

    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    
    IEnumerator Reloadpistol ()
    {
        isReloading = true;
        PlaySound(reloadSound);
        Debug.Log("Reloading...");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime -.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        var shot = maxmagAmmo - pistolAmmo;
        if(pistolinvAmmo < shot)
        {
            pistolAmmo += shot;
            pistolinvAmmo = 0;
        }
        else
        {
pistolAmmo += shot;
pistolinvAmmo -= shot;
        }
        ammo = maxmagAmmo;

        isReloading = false;
    }

      IEnumerator Reloadmachine ()
    {
        isReloading = true;
        PlaySound(reloadSound);
        Debug.Log("Reloading...");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime -.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        var shot = maxmagAmmo - machineAmmo;
        if(machineinvAmmo < shot)
        {
            machineAmmo += shot;
            machineAmmo = 0;
        }
        else
        {
machineAmmo += shot;
machineinvAmmo -= shot;
        }
        ammo = maxmagAmmo;

        isReloading = false;
    }
    void Shoot ()
    {

        ShotFlash.Play();
        ammo--;
    
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
void Shootpistol ()
    {

        ShotFlash.Play();
        ammo--;

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
void Shootmachine ()
    {

        ShotFlash.Play();
        ammo--;
 
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

