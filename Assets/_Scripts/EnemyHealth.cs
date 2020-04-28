using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health;
    public bool isDead;
    private float scoreValue = 150f;

    Animator anim;
    private GameObject sm;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        anim = GetComponent<Animator> ();
        sm = GameObject.Find ("ScoreManager");
    }

    // Update is called once per frame
    void Update()
    {
    }


    IEnumerator Death (float Count) {
        yield return new WaitForSeconds (Count); //Count is the amount of time in seconds that you want to wait.
        Destroy(gameObject);
        yield return null;
    }

    void DeadAnimation() {
        anim.SetBool ("isDead", true);
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Bullet") {
            Debug.Log("Bullet Hit");
            health -= 1;
            if(health == 0){
                DeadAnimation();
                StartCoroutine("Death", 0.4f);
                sm.GetComponent<ScoreScript>().gemScore(scoreValue);
            }
        }
	}
}
