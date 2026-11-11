using CodeBase.InteractionSystem;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private PlayerInteraction _playerInteraction;
    //TODO: refactor to clips if theres lots of player sounds 
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        _playerInteraction = GetComponentInParent<PlayerInteraction>();
        _playerInteraction.OnInteract.AddListener(PlayInteractionSound);
    }

    private void PlayInteractionSound()
    {
        if (!audioSource) return;
        audioSource.Play();
    }
}
