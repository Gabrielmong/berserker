using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{

    [SerializeField]
    private GameObject PauseMenu;

    [SerializeField]
    AudioClip backgroundMusic;

    [SerializeField]
    float musicVolume;

    private void Start()
    {
        PauseMenu?.SetActive(false);

        // play the background music
        if (backgroundMusic != null)
        {
            GameObject backgroundMusicObject = new GameObject("BackgroundMusic");
            AudioSource audioSource = backgroundMusicObject.AddComponent<AudioSource>();

            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.volume = musicVolume;
            audioSource.Play();



        }


    }

    // function to pause the game
    public void PauseGame()
    {
        Time.timeScale = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResumeGame();
        }
    }

    // function to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu?.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu?.SetActive(true);
            PauseGame();
        }
    }
}
