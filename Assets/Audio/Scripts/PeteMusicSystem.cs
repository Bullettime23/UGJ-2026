using System.Collections;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Audio;

public class PeteMusicSystem : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioSource musicA;
    [SerializeField] private AudioSource musicB;
    
    private AudioSource activeMusic;
    private Coroutine musicTransition;

    private void Awake()
    {
        activeMusic = musicA;
        musicA.volume = 1f;
        musicB.volume = 0f; 
    }

    [ProButton]
    public void PlayMusic(AudioClip clip, float fadeDuration = 2f)
    {
        if (clip == null) return;

        if (activeMusic.clip == clip && activeMusic.isPlaying) return;

        if (musicTransition != null)
        {
            StopCoroutine(musicTransition);
        }

        musicTransition = StartCoroutine(CrossfadeMusic(clip, fadeDuration));
            
    }
    
    [ProButton]
    public void StopMusic(float fadeDuration = 1f)
    {
        if (musicTransition != null)
            StopCoroutine(musicTransition);

        musicTransition = StartCoroutine(
            FadeOutMusic(fadeDuration)
        );
    }

    private IEnumerator CrossfadeMusic(AudioClip clip, float duration)
    {
        AudioSource incoming = (activeMusic == musicA) ? musicB : musicA;
        AudioSource outgoing = activeMusic;
        
        incoming.clip = clip;
        incoming.volume = 0f;
        incoming.Play();
        
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            incoming.volume = t;
            outgoing.volume = 1f - t;

            yield return null;
        }
        
        outgoing.Stop();
        outgoing.volume = 0f;
        incoming.volume = 1f;
        
        activeMusic = incoming;
        musicTransition = null;
    }
    
    private IEnumerator FadeOutMusic(float duration)
    {
        float startVolume = activeMusic.volume;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            activeMusic.volume = Mathf.Lerp(
                startVolume, 0f,
                Mathf.Clamp01(elapsed / duration)
            );

            yield return null;
        }

        activeMusic.Stop();
        activeMusic.volume = 0f;
        musicTransition = null;
    }
}
