using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    private float musicVolume = 1f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
    }
    public void FullScene(bool is_fullscene)
    {
        Screen.fullScreen = is_fullscene;
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
