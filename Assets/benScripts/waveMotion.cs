using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMotion : MonoBehaviour {

    float totTime = 0;

    int xVelocity = -1;
    int yVelocity = 0;
    float adjustedYVel = 0;
    float adjustedXVel = 0;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        totTime += Time.deltaTime;
        adjustedYVel = (float)0.5 * (yVelocity + Mathf.Sin(totTime));
        adjustedXVel = (float)0.2 * (xVelocity + Mathf.Sin(totTime));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(xVelocity, adjustedYVel);
    }
}
