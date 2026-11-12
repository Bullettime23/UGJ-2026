using System;
using com.cyborgAssets.inspectorButtonPro;
using StarterAssets;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    private AudioSource footstepSource;
    private FirstPersonController playerController;
    [SerializeField] [Range(0.1f, 1.0f)] private float walkStepInterval = 0.5f;
    [SerializeField][Range(0.1f, 1.0f)] private float sprintStepInterval = 0.3f;
    [SerializeField][Range(0.1f, 1.0f)] private float crouchStepInterval = 0.7f;

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
