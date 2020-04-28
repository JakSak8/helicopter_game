using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    float score;
    bool endGame;

    private GameObject WindmillSpawn;
    private GameObject GemSpawn;
    private GameObject BackgroundController1;
    private GameObject BackgroundController2;
    private GameObject scoreManager;
    private GameObject[] windmills;
    private GameObject[] gems;

    private float playerScore;

    public GameObject[] Players;

    void Awake () {
        Time.timeScale = 1;
        WindmillSpawn = GameObject.Find ("WindmillSpawner");
        GemSpawn = GameObject.Find ("GemSpawner");
        BackgroundController1 = GameObject.Find ("Scenery/Background1");
        BackgroundController2 = GameObject.Find ("Scenery/Background2");
        scoreManager = GameObject.Find ("ScoreManager");
        PlayerPrefs.SetInt("finishedGame", 0);
        ChoosePlayer ();
    }

    // Start is called before the first frame update
    void Start () {
        endGame = false;
    }

    // Update is called once per frame
    void Update () {

    }

    IEnumerator Reset (float Count) {
        yield return new WaitForSeconds (Count); //Count is the amount of time in seconds that you want to wait.
        SceneManager.LoadScene("Leaderboard");
        yield return null;
    }

    public void addScore () {
        score++;
    }

    public void EndGame () {
        stopObjects ();
        playerScore = scoreManager.GetComponent<ScoreScript> ().GetScore ();
        PlayerPrefs.SetFloat ("currentScore", playerScore);
        PlayerPrefs.SetInt("finishedGame", 1);
        StartCoroutine("Reset", 1.5f);
    }

    public bool isGameOver () {
        return endGame;
    }

    void stopObjects () {
        WindmillSpawn.SetActive (false);
        GemSpawn.SetActive (false);
        windmills = GameObject.FindGameObjectsWithTag ("Windmill");
        foreach (GameObject windmill in windmills) {
            windmill.GetComponent<WindmillBehaviour> ().SetSpeed (0);
        }
        gems = GameObject.FindGameObjectsWithTag ("Gem");
        foreach (GameObject gem in gems) {
            gem.GetComponent<GemBehaviour> ().SetSpeed (0);
        }
        BackgroundController1.GetComponent<MovingBackground> ().StopBackground ();
        BackgroundController2.GetComponent<MovingBackground> ().StopBackground ();
    }

    public void ChoosePlayer () {
        string p = PlayerPrefs.GetString ("player", "");
        Debug.Log (p);
        foreach (GameObject player in Players) {
            if (player.name == p) {
                Debug.Log (player);
                player.SetActive (true);
            } else {
                player.SetActive (false);
            }
        }
    }
}