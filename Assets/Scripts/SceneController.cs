using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void NextScene()
   {
         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
         SceneManager.LoadScene(currentSceneIndex + 1);
   }

   public void FirstScene()
   {
         SceneManager.LoadScene(0);
   }
}
