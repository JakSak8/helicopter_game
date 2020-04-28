using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
    public InputField playerName;
    public static string pName;
    float playerScore;

    public Text[] highScores;

    float [] highScoreValues;
    string [] highScoreNames;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(PlayerPrefs.GetInt("finishedGame", 0) == 0) {
            GameObject.FindWithTag("SubmitButton").GetComponent<Button>().interactable = false;
        }

        highScoreValues = new float[5];
        highScoreNames = new string[5];

        for(int i = 0; i < highScores.Length; i++)
        {
            highScoreValues [i] =  PlayerPrefs.GetFloat("highScoreValues" + i);
            highScoreNames [i] = PlayerPrefs.GetString("highScoreNames" + i);
        }
        DisplayScores();
    }

    void DisplayScores()
    {
        Debug.Log("Display Scores");
        for (int i = 0; i < highScores.Length; i++){
            highScores[i].text = highScoreValues[i].ToString() + " | " + highScoreNames[i];
        }
    }

    public void CheckHighScore(float score, string name){
        for (int i = 0; i < highScores.Length; i++)
        {
            if(score >= highScoreValues[i])
            {
                Debug.Log("why doesnt this work");
                for(int j = highScores.Length - 1; j > i; j--)
                {
                    highScoreValues[j] = highScoreValues[j - 1];
                    highScoreNames[j] = highScoreNames[j - 1];
                }
                highScoreValues[i] = score;
                highScoreNames[i] = name;
                Debug.Log("this fires");
                DisplayScores();
                SaveScores();
                break;
            }
        }
    }
    
    void SaveScores()
    {
        for(int i = 0; i < highScores.Length; i++)
        {
            PlayerPrefs.SetFloat("highScoreValues" + i, highScoreValues[i]);
            PlayerPrefs.SetString("highScoreNames" + i, highScoreNames[i]);
        }
    }

    public void Submit() 
    {
        playerScore = PlayerPrefs.GetFloat("currentScore", 0.0f);
        pName = playerName.text;
        if (name == "" || name == null) {
            return;
        }
        CheckHighScore(playerScore, pName);
        PlayerPrefs.SetInt("finishedGame", 0);
        SceneManager.LoadScene("MainPage");
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainPage");
    }
}
