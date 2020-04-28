using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    private GameObject background;
    private float groundHorizontalLength;
    
    // Start is called before the first frame update
    void Start()
    {
        //Store the size of the collider along the x axis (its length in units).
        groundHorizontalLength = 24.23f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
            RepositionBackground ();
        }
    }

    //Moves the object this script is attached to right in order to create our looping background effect.
    private void RepositionBackground()
    {   
        // float n = groundHorizontalLength * 2f;
        //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
        transform.position = new Vector2(24.23f, -0.7433745f);
    }
}
