using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectController : MonoBehaviour
{

    public GameObject[] players;
    int index;


    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRight() {
        if(index == players.Length - 1){
            index = 0;
        } else {
            index += 1;
        }
        Debug.Log(index + "| Left");
        UpdatePlayer();
    }

    public void MoveLeft() {
        if(index == 0) {
            index = players.Length -1;
        } else {
            index -= 1;
        }
        Debug.Log(index + "| Right");
        UpdatePlayer();
    }

    void UpdatePlayer()
    {
        for (int i = 0; i < players.Length; i++){
            if(i == index){
                players[i].SetActive(true);
                PlayerPrefs.SetString("player", players[i].name);
                Debug.Log(players[i]);
            } else {
                Debug.Log(players[i]);
                players[i].SetActive(false);
            }
        }
    }

    public void Select() {
       SceneManager.LoadScene("MainPage"); 
    }
}
