using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationEvents : MonoBehaviour
{
    [SerializeField] private PlayerAudioController audioController;

    public void PlayWalkSound()
    {
        audioController.PlayWalkSound();
    }

    public void PlayFallSound()
    {
        audioController.PlatFallSound();
    }
}
