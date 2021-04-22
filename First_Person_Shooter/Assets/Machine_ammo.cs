using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_ammo : MonoBehaviour
{
    
     public GameObject ammoBox;
    public Gun script;
    // Start is called before the first frame update

    void Update()
    {
        script = GameObject.Find("Player/Main Camera/Weapon_Holder/Machine Gun(Clone)").GetComponent<Gun>();
    }
 void OnTriggerEnter(Collider other)
 {
     
     ammoBox.SetActive(false);
     script.pistolinvAmmo += 70;
 }
}
