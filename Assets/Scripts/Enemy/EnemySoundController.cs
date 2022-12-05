using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    [SerializeField]
    AudioClip deathSound;

    [SerializeField]
    AudioClip deathSoundOptional;

    [SerializeField]
    AudioClip hurtSound;

    [SerializeField]
    AudioClip hurtSound2;

    [SerializeField]
    AudioClip hurtSound3;

    [SerializeField]
    AudioClip attackSound;

    [SerializeField]
    AudioClip walkSound;

    [SerializeField]
    AudioClip hitSound;


    public void PlayDeathSound()
    {
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }

        if (deathSoundOptional != null)
        {
            AudioSource.PlayClipAtPoint(deathSoundOptional, transform.position);
        }
    }

    public void PlayHurtSound()
    {
        if (hurtSound != null)
        {
            // randomly play one of the 3 hurt sounds
            int random = Random.Range(0, 3);

            if (random == 0)
            {
                AudioSource.PlayClipAtPoint(hurtSound, transform.position);
            }
            else if (random == 1)
            {
                AudioSource.PlayClipAtPoint(hurtSound2, transform.position);
            }
            else if (random == 2)
            {
                AudioSource.PlayClipAtPoint(hurtSound3, transform.position);
            }
        }
    }

    public void PlayAttackSound()
    {
        if (attackSound != null)
        {
            AudioSource.PlayClipAtPoint(attackSound, transform.position);
        }
    }

    public void PlayWalkSound()
    {
        if (walkSound != null)
        {
            AudioSource.PlayClipAtPoint(walkSound, transform.position);
        }
    }

    public void PlayHitSound()
    {
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }
    }


}
