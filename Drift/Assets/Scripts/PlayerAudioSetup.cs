using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioSetup : MonoBehaviour
{
    public AudioSource footStepAudio, slideAudio, rollAudio;
    // Start is called before the first frame update
    public void PlayFootStep()
    {
        footStepAudio.Play();
    }

    public void PlaySlide()
    {
        slideAudio.Play();
    }

    public void playRoll()
    {
        rollAudio.Play();
    }
}
