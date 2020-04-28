using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterBehaviour : MonoBehaviour {

    public float velocity = 1;
    private Rigidbody2D rigidbody;
    Animator anim;
    public GameObject GameManager;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start () {
        rigidbody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        explosionEffect.GetComponent<ParticleSystem>().loop = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey ("space")) {
            // if(GameManager.GetComponent<GameManagerScript>())
            rigidbody.velocity = Vector2.up * velocity;
            Animating (true);
        } else {
            Animating (false);
        }
    }

    void Animating (bool flying) {
        // Tell the animator whether or not the player is flying.
        anim.SetBool ("isFlying", flying);
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
            BlowUp();
            GameManager.GetComponent<GameManagerScript>().EndGame();
        }
	}

    public void BlowUp () {
        Instantiate (explosionEffect, transform.position, transform.rotation);
        transform.Rotate (0f, 0f, 180f);
        Debug.Log ("BOOM");
        velocity = 0;
    }
}