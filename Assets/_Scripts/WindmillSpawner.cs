using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillSpawner : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject windmill;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(windmill, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > maxTime)
        {
            GameObject newWindmill = Instantiate(windmill);
            Destroy(newWindmill, 30);
            timer = 0;
            Random.InitState(System.DateTime.Now.Millisecond + 9);
            // maxTime = Random.Range(3, 7);
            Debug.Log(maxTime);
        }

        timer += Time.deltaTime;
    }
}
