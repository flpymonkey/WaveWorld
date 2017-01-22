using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateWhenRender : MonoBehaviour {

    public int eventualMass = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Renderer>().isVisible)
        {
            Debug.Log("in frame");
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<Rigidbody2D>().mass = eventualMass;
        }
	}
}
