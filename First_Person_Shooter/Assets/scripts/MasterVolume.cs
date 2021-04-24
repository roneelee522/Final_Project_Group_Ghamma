using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolume : MonoBehaviour
{    
    private AudioListener listener;
    private float masterVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        listener = GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = masterVolume;
    }
    public void SetAllVolume(float vol)
    {
        masterVolume = vol;
    }
}
