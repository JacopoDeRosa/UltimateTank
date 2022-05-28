using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private ParticleSystem _particleSystem;


    public void ToggleFire(bool firing)
    {
        if(firing)
        {
            _audio.Play();
            _particleSystem.Play();
        }
        else
        {
            _audio.Stop();
            _particleSystem.Stop();
        }
    }
}
