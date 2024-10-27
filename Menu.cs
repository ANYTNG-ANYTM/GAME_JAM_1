using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void menu()
    {
        FindAnyObjectByType<AudioManager>().Play("Click");
        SceneManager.LoadScene(0);
    }
}
