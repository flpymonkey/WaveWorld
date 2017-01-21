using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreCol : MonoBehaviour {

    public GameObject wave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), wave.GetComponent<Collider2D>());
		
	}
}
