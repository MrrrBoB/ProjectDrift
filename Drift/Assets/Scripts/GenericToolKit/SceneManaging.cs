using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    
    public void loadScn(int scnfour)
    {
        SceneManager.LoadScene(scnfour);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
