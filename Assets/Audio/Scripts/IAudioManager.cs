using LevGamekit.Infrastructure.ServiceLocator;
using UnityEngine;

public interface IAudioManager : IService
{
    void PlayDeathSFX();
    void PlaySFX(AudioClip clip, float volume = 1);
    void SetVolume(string parameter, float value);
}