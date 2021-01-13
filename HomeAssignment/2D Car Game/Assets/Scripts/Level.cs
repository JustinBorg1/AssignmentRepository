using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("EndGame");
    }

    //you can call a scene either by its name or its index
    public void LoadGame()
    {
        SceneManager.LoadScene("2DcarGame");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadStartMenu()
    {
        //(0) since it is the starting scene
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        //unity's console is print not console.writeline
        print("Quitting Game");
        //will only work as .EXE
        Application.Quit();
    }
}
