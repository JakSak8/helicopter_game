using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    bool up;


    // Start is called before the first frame update
    void Start()
    {
        up = true;
        MoveUp();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * horizontalSpeed * Time.deltaTime;

        if (up == true){
            if(transform.position.y >= 3) {
                up = false;
                MoveDown();
            } else {
                MoveUp();
            }
        } else {
            if(transform.position.y <= -3){
                up = true;
                MoveUp();
            } else {
                MoveDown();
            }
        }

        // } else if (transform.position.y <= -3 && up == false){
        //     MoveUp();
        //     up = true;
        // }
    }

    public void SetSpeed(float s){
        horizontalSpeed = 0;
        verticalSpeed = 0;
    }

    void MoveUp() {
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
    }

    void MoveDown() {
        transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
    }
}
