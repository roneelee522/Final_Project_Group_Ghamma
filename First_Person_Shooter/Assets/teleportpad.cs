using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportpad : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    // Update is called once per fram

    void OnTriggerEnter(Collider other)
    {
            thePlayer.transform.position = teleportTarget.transform.position;
     
    }
}
