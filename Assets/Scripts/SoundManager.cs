using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip uiButton;
    public AudioClip jump;
    public AudioClip fire;
    public AudioClip swing;
    public AudioClip takeDamage;
    public AudioClip explosion;


    private AudioSource audio;
  

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        audio = GetComponent<AudioSource>();
    }

 

  
    public void UIClickSfx()
    {
        audio.PlayOneShot(uiButton);
    }

    public void JumpSfx()
    {
        audio.PlayOneShot(jump);
    }


    public void FireSfx()
    {
        audio.PlayOneShot(fire);
    }

    public void SwingSfx()
    {
        audio.PlayOneShot(swing);
    }

    public void TakeDamageSfx()
    {
        audio.PlayOneShot(takeDamage);
    }

    public void ExplosionSfx()
    {
        audio.PlayOneShot(explosion);
    }


}
