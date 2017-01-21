using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contMotion : MonoBehaviour {

    int xVelocity = -3;
    int yVelocity = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(xVelocity, yVelocity);
        ///if (gameObject.)
    }
}
