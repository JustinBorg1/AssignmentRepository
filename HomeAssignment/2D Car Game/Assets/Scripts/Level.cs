using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoadEnd()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("EndGame");
    }
    IEnumerator WaitAndLoadWinner()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("WinnerScene");
    }

    //you can call a scene either by its name or its index
    public void LoadGame()
    {
        SceneManager.LoadScene("2DcarGame");
        GameSession gs = FindObjectOfType<GameSession>();
        if (gs != null)
        {
            gs.ResetGame();
        }
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoadEnd());
    }

    public void LoadWinnerScene()
    {
        StartCoroutine(WaitAndLoadWinner());
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
