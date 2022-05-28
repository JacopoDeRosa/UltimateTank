using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _fireAudio;
    [SerializeField] private ParticleSystem _shotParticle;
    [SerializeField] private float _fireDelay;

    private float _nextShotTime;

    public bool Fire()
    {
        if(Time.time > _nextShotTime)
        {
            _shotParticle.Play();
            _audioSource.PlayOneShot(_fireAudio);
            _nextShotTime = Time.time + _fireDelay;
            return true;
        }

        return false;
    }
}
