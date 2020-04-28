using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > maxTime)
        {
            GameObject newEnemy = Instantiate(enemy);
            Destroy(newEnemy, 30);
            timer = 0;
            Random.InitState(System.DateTime.Now.Millisecond + 9);
            maxTime = Random.Range(4, 9);
            Debug.Log(maxTime);
        }

        timer += Time.deltaTime;
    }
}
