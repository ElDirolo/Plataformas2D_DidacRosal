using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    private AudioSource _audioSource;

    public AudioClip Impacto;

    public AudioClip Recolectado;

    public AudioClip VidaExtra;

    public AudioClip Derrota;

    public AudioClip Victoria;


    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void GolpeSound()
    {
        _audioSource.PlayOneShot(Impacto);
    }

    public void EstellaSound()
    {
        _audioSource.PlayOneShot(Recolectado);
    }

    public void VidaSound()
    {
        _audioSource.PlayOneShot(VidaExtra);
    }

    public void VictoriaSound()
    {
        _audioSource.PlayOneShot(Victoria);
    }

    public void DerrotaSound()
    {
        _audioSource.PlayOneShot(Derrota);
    }
}
