using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void gemScore(float value)
    {
        score += value;
    }

    public void enemyScore(float value)
    {
        score += value;
    }

    public float GetScore() {
        return score;
    }
}
