using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Gun_Pickup : MonoBehaviour
{
 public GameObject pickup;
 public Weapon_Switcher script;
 public Gun script2;
  public GameObject prefab;
    public Transform parent;
    public GameObject pistol;
void OnTriggerEnter(Collider other)
{
    pickup.SetActive(false);
    pistol.SetActive(false);
    GameObject childGameObject = Instantiate(prefab, parent);
    script.selectedWeapon = 1;
        script2.currentAmmoText.text = script2.machineAmmo.ToString ();
    script2.invAmmoText.text = script2.machineinvAmmo.ToString ();

}

   
}
