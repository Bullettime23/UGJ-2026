using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraShake : MonoBehaviour
{
    public CinemachineBasicMultiChannelPerlin perlinNoise;

    private void Awake()
    {
       
    }

    public void Shake(float intensity, float duration)
    {
        perlinNoise.AmplitudeGain = intensity;
        Invoke(nameof(StopShake), duration);
    }

    private void StopShake()
    {
        perlinNoise.AmplitudeGain = 0f;
    }
}
