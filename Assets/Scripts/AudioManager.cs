using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip drink, door, gegenstand, glitter;
    
    public void PlayDrinkSound(AudioSource audioSource)
    {
        audioSource.clip = drink;
        audioSource.Play();
    }

    public void PlayDoorSound(AudioSource audioSource)
    {
        audioSource.clip = door;
        audioSource.Play();
    }
    
    public void PlayGegenstandSound(AudioSource audioSource)
    {
        audioSource.clip = gegenstand;
        audioSource.Play();
    }
    
    public void PlayGlitterSound(AudioSource audioSource)
    {
        audioSource.clip = glitter;
        audioSource.Play();
    }
}
