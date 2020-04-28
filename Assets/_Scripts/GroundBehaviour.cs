using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehaviour : MonoBehaviour
{

    private GameObject Player;
    private GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        GameManager = GameObject.FindWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
            Player.GetComponent<HelicopterBehaviour>().BlowUp();
            GameManager.GetComponent<GameManagerScript>().EndGame();
        }
	}
}
