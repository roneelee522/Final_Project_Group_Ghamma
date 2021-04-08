using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportpad : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    public GameObject transition;
    public AudioSource audioSource;
    public AudioClip teleportSound;

    void Start()
    {
        transition.SetActive(false);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    // Update is called once per fram
    void OnTriggerEnter(Collider other)
    {

        transition.SetActive(true);
        PlaySound(teleportSound);
        thePlayer.transform.position = teleportTarget.transform.position;
    }
    void OnTriggerExit(Collider other)
    {
        StartCoroutine("Wait");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        transition.SetActive(false);
    }
}
