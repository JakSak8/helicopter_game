using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomepageController : MonoBehaviour
{

    void Awake() {
        PlayerPrefs.SetInt("finishedGame", 0);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Play() {
        SceneManager.LoadScene("Level1");
    }

    public void Quit() {
        Application.Quit();
    }

    public void Custom() {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void Leaderboard() {
        SceneManager.LoadScene("Leaderboard");
    }


}
