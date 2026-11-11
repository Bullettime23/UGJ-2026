using System;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class AmbienceAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource ambienceSource;
    [SerializeField] private AudioSource ambienceOneSource;
    public List<AudioClip> ambiOneShots;
    [SerializeField] private Vector2 oneShotIntervalTimeRange = new Vector2(5f, 15f);
     private Vector2 oneShotVolumeRange = new Vector2(0.25f, 1f);
     private Vector2 oneShotPitchRange = new Vector2(0.70f, 1.3f);
     private Vector2 oneShotPanRange = new Vector2(-1f, 1f);

     //timer system for playing one shot ambience
     private float oneShotTimer;
     private float nextOneShotTimer;

     private void Start()
     {
         ScheduleNextOneShot();
     }

     private void ScheduleNextOneShot()
     {
         nextOneShotTimer = GetRandomFloat(oneShotIntervalTimeRange);
         oneShotTimer = 0f;
     }
     
     private void Update()
     {
         oneShotTimer += Time.deltaTime;
         if (oneShotTimer >= nextOneShotTimer)
         {
             PlayOneShotAmbience();
             ScheduleNextOneShot();
         }
     }

     [ProButton]
     public void PlayOneShotAmbience()
     {
            if (ambiOneShots.Count == 0) return;
    
            Debug.Log("Playing ambience one shot");
            AudioClip randomAmbience = ambiOneShots[Random.Range(0, ambiOneShots.Count)];
            float randomVolume = GetRandomFloat(oneShotVolumeRange);
            float randomPitch = GetRandomFloat(oneShotPitchRange);
            float randomPan = GetRandomFloat(oneShotPanRange);
            ambienceOneSource.panStereo = randomPan;
            ambienceOneSource.pitch = randomPitch;
            ambienceOneSource.PlayOneShot(randomAmbience, randomVolume);
     }

     private float GetRandomFloat(Vector2 range)
    {
        return Random.Range(range.x, range.y);
    }
}
