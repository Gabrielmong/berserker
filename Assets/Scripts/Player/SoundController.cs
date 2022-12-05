using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    AudioClip stepSound;

    [SerializeField]
    AudioClip runSound;
    
    [SerializeField]
    AudioClip attackSound;

    [SerializeField]
    AudioClip attackSound2;

    [SerializeField]
    AudioClip deathSound;

    [SerializeField]
    AudioClip hurtSound;

    [SerializeField]
    AudioClip jumpSound;

    [SerializeField]
    AudioClip landSound;

    
    public void PlayStepSound()
    {
        if (stepSound != null)
        {
            AudioSource.PlayClipAtPoint(stepSound, transform.position);
        }
    }

    public void PlayRunSound()
    {
        if (runSound != null)
        {
            AudioSource.PlayClipAtPoint(runSound, transform.position);
        }
    }

    public void PlayAttackSound()
    {
        if (attackSound != null)
        {
            AudioSource.PlayClipAtPoint(attackSound, transform.position);
        }
    }

    public void PlayAttackSound2()
    {
        if (attackSound2 != null)
        {
            AudioSource.PlayClipAtPoint(attackSound2, transform.position);
        }
    }

    public void PlayDeathSound()
    {
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
    }

    public void PlayHurtSound()
    {
        if (hurtSound != null)
        {
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
        }
    }

    public void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }
    }

    public void PlayLandSound()
    {
        if (landSound != null)
        {
            AudioSource.PlayClipAtPoint(landSound, transform.position);
        }
    }




}
