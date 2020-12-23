using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScore : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreDisplay.scoreValue += 5;
        if (ScoreDisplay.scoreValue == 100)
        {
            SceneManager.LoadScene("Win");
            FindObjectOfType<ScoreDisplay>().ResetScore();
            FindObjectOfType<GameSession>().ResetGame();
        }
    }
}
