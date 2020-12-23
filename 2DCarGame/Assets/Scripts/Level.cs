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
        SceneManager.LoadScene("Over");
    }


    public void LoadStartMenu()
    {
        //loads the first scene in the Project
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
        FindObjectOfType<ScoreDisplay>().ResetScore();
    }

    public void LoadStartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameAfterWin_()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
