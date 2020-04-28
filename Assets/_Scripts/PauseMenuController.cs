using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start () {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) 
        {
            if (Time.timeScale == 1) 
            {
                Time.timeScale = 0;
                showPaused ();
            } else 
            {
                Time.timeScale = 1;
                hidePaused ();
            }
        }
    }
    //shows objects with ShowOnPause tag
    public void showPaused () {
        PauseMenu.SetActive (true);
    }

    //hides objects with ShowOnPause tag
    public void hidePaused () {
        PauseMenu.SetActive (false);
    }

    public void Restart () {
        SceneManager.LoadScene ("Level1");
    }

    public void MainMenu () {
        SceneManager.LoadScene ("MainPage");
    }
}
