using System;
using CodeBase.Utility;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireTrapAudio : MonoBehaviour
{
    private AudioSource fireTrapSource;
    private FireTrap fireTrap;

    private void Awake()
    {
         fireTrapSource = GetComponent<AudioSource>();
         fireTrap = GetComponentInParent<FireTrap>();
         fireTrap.OnFireEnabled.AddListener(PlayFireTrapSound);
    }

   public void PlayFireTrapSound()
    {
        if (!fireTrapSource) return;
        fireTrapSource.pitch = Random.Range(0.9f, 1.2f);
        fireTrapSource.volume = Random.Range(0.6f, 0.9f);
        fireTrapSource.Play();
    }
}
