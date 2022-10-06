using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips deadAudioClips;
    [SerializeField] private SoAudioClips fallAudioClips;
    private float volume = 0.3f;

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClips.GetAudioClip(),volume); 
    }

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip(),volume);
    }

    public void PlayDeadSound()
    {
        audioSource.PlayOneShot(deadAudioClips.GetAudioClip(), volume);
    }

    public void PlatFallSound()
    {
        audioSource.PlayOneShot(fallAudioClips.GetAudioClip(),volume ); 
    }
}
