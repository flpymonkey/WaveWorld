using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contMotion : MonoBehaviour {

    int xVelocity = -5;
    int yVelocity = 0;
    public int worldLimit = -30;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(xVelocity, yVelocity);
        if (gameObject.GetComponent<Transform>().position.x <= worldLimit)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(5, -3);
        }
    }
}
