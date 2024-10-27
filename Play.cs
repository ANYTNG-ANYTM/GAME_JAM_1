using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
   public void PlayGame()
    {
        FindAnyObjectByType<AudioManager>().Play("Click");
        SceneManager.LoadScene(1);
    }
}
