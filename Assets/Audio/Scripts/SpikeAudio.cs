using UnityEngine;

public class SpikeAudio : MonoBehaviour
{
    private AudioSource spikeSource;
    private PingPongMotion pingPongMotion;
    public AudioClip forwardSpikeClip;
    public AudioClip backwardSpikeClip;

    private void Awake()
    {
        spikeSource = GetComponent<AudioSource>();
        pingPongMotion = GetComponentInParent<PingPongMotion>();
        pingPongMotion.OnWentForward.AddListener(OnSpikeDirectionChanged);
    }

    private void OnSpikeDirectionChanged(bool arg0)
    {
        if(arg0 == true)
        {
            PlaySpikeSound(SpikeAudioType.FORWARD);
        }
        else
        {
            PlaySpikeSound(SpikeAudioType.BACKWARD);
        }
    }

    public void PlaySpikeSound(SpikeAudioType spikeAudioType)
    {
        
        if (!spikeSource) return;
        spikeSource.pitch = Random.Range(1.8f, 2.2f); 
        switch (spikeAudioType)
        {
            case SpikeAudioType.FORWARD:
                spikeSource.clip = forwardSpikeClip;
                break;
            case SpikeAudioType.BACKWARD:
                spikeSource.clip = backwardSpikeClip;
                break;
            default:
                Debug.LogWarning("Unknown SpikeAudioType: " + spikeAudioType);
                return;
        }

        spikeSource.Play();
    }
}


public enum SpikeAudioType
{
    FORWARD,
    BACKWARD
}