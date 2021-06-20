using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVolume : MonoBehaviour
{
    public AudioSource Audio; // our audio to be played
    private float audioVolume = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        Audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Audio.volume = audioVolume;
    }

    public void updateVolume(float volume)
    {
        audioVolume = volume;
    }
}
