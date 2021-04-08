using UnityEngine;

public class Weapon_Switcher : MonoBehaviour
{
    public int selectedWeapon = 0;
    public AudioSource audioSource;
    public AudioClip switchSound;

    void Start()
    {
        SelectWeapon();
    }

     public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void Update()
    {
    int previousSelectedWeapon = selectedWeapon;
if (Input.GetKeyDown(KeyCode.Alpha1))
{
    selectedWeapon = 0;
            PlaySound(switchSound);
        }
 if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
{
    selectedWeapon = 1;
    PlaySound(switchSound);
}


    if (previousSelectedWeapon != selectedWeapon)
    {   
        SelectWeapon();
    }
        
    }
    void SelectWeapon ()
    {
        int i = 0;
    foreach (Transform weapon in transform)
{
    if (i == selectedWeapon)
    weapon.gameObject.SetActive(true);
    else 
    weapon.gameObject.SetActive(false);
    i++;
}
    }
}
