using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip ambient;
    public AudioClip death;
    public AudioClip liraPath;
    public AudioClip liraReveal;
    public AudioClip hide;

    private void Start()
    {
        musicSource.clip = ambient;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
