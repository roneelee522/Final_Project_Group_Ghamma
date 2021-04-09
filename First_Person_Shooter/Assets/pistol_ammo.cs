using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistol_ammo : MonoBehaviour
{
        public GameObject ammoBox;
    public Gun script;
    // Start is called before the first frame update
 void OnTriggerEnter(Collider other)
 {
     ammoBox.SetActive(false);
     script.pistolinvAmmo += 20;
 }

}
