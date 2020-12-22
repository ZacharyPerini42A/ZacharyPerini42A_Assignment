using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text score;
    public static int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        GameSession gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Points: " + scoreValue;
    }

    public void ResetScore()
    {
        scoreValue = 0;
        score.text = "Points: " + scoreValue;
    }
}
