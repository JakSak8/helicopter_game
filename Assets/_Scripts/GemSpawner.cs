using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{

    public float maxTime = 0.5f;
    private float timer = 0f;
    public GameObject gem;
    public float height;
    public Collider2D[] colliders;

    public float powerupMaxTime = 1f;
    private float powerupTimer = 0f;
    public GameObject redGem;
    public float powerupHeight;

    bool powerIsActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > maxTime)
        {
            GameObject newGem = Instantiate(gem);
            newGem.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 1);
            Destroy(newGem, 10);
            timer = 0;
            Random.InitState(System.DateTime.Now.Millisecond);
            maxTime = Random.Range(4, 7);
        }

        if(powerupTimer > powerupMaxTime) {
            GameObject newRedGem = Instantiate(redGem);
            newRedGem.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 1);
            Destroy(newRedGem, 10);
            powerupTimer = 0;
            Random.InitState(System.DateTime.Now.Millisecond);
            powerupMaxTime = Random.Range(30f, 60f);
        }

        powerupTimer += Time.deltaTime;
        timer += Time.deltaTime;
    }


    public void PowerupActivated() {
        // powerIsActive = true;
        for(int i = 0; i < 10; i++){
            float delay = i * 0.000001f;
            StartCoroutine("Timer", i);
        }
        // StartCoroutine("RapidSpawn", 2f);
    }

    IEnumerator RapidSpawn (float Count) {
        yield return new WaitForSeconds (Count); //Count is the amount of time in seconds that you want to wait.
        powerIsActive = false;
        yield return null;
    }

    IEnumerator Timer (float Count) {
        yield return new WaitForSeconds (Count); //Count is the amount of time in seconds that you want to wait.
        GameObject newGem = Instantiate(gem);
        newGem.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 1);
        Destroy(newGem, 10);
        yield return null;
    }

}
