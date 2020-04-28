using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    public float speed;
    private GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("GemSpawner");
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
            spawner.GetComponent<GemSpawner>().PowerupActivated();
			Destroy(gameObject);
        } else if (other.gameObject.tag == "Windmill") {
            transform.position += Vector3.up * 1f;
        }
	}



    public void SetSpeed(float s){
        speed = s;
    }
}
