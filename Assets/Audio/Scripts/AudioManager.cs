using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("SFX Audio")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource uiSource;
    
    
    [Header("UI sounds")]
    public AudioClip deathClip;
    
    [Header("Mixer")]
    [SerializeField] private AudioMixer mixer;

    [ProButton]
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip, volume);
    }

    [ProButton]
    private void PlayUI(AudioClip clip, float volume = 1f)
    {
        if (clip != null)
            uiSource.PlayOneShot(clip, volume);
    }


    public void PlayDeathSFX()
    {
        uiSource.pitch = Random.Range(0.95f, 1.05f);
        PlayUI(deathClip);
    }
    
    public void SetVolume(string parameter, float value)
    {
        float db = value <= 0.0001f
            ? -80f
            : Mathf.Log10(value) * 20f;

        mixer.SetFloat(parameter, db);
    }
}
