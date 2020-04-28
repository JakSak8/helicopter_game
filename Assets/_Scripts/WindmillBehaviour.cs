using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillBehaviour : MonoBehaviour
{
    public float speed;
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
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
            speed = 0;
            Player.GetComponent<HelicopterBehaviour>().BlowUp();
            GameManager.GetComponent<GameManagerScript>().EndGame();
        }
	}

    public void SetSpeed(float s){
        speed = s;
    }

}
