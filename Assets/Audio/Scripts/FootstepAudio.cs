using System;
using com.cyborgAssets.inspectorButtonPro;
using StarterAssets;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    private AudioSource footstepSource;
    private FirstPersonController playerController;
   

    private float _footstepTimer;
    private void Awake()
    {
        footstepSource = GetComponent<AudioSource>();
        playerController = GetComponentInParent<FirstPersonController>();
        playerController.OnFootstep.AddListener(PlayFootstep);
    }
    
    [ProButton]
    private void PlayFootstep()
    {
        if (!footstepSource) return;
        footstepSource.Play();
    }
}
