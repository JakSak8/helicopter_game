using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{

    public float speed;
    public float scoreValue =  100f;
    private GameObject sm;


    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.Find ("ScoreManager");
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
            sm.GetComponent<ScoreScript>().gemScore(scoreValue);
			Destroy(gameObject);
        } else if (other.gameObject.tag == "Windmill") {
            Debug.Log("Windmill Collision");
            transform.position += Vector3.up * 1f;
        }
	}

    public void SetSpeed(float s){
        speed = s;
    }
}
