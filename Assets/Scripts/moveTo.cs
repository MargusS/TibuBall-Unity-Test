using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveTo : MonoBehaviour
{
    public void changueScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
