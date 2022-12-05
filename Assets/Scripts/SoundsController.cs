using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [SerializeField]
    AudioClip healUpSound;

    

    public void PlayHealUpSound()
    {
        if (healUpSound != null)
        {
            AudioSource.PlayClipAtPoint(healUpSound, transform.position);
        }
    }
}


