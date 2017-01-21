using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void OnCollisionEnter2D(Collision2D collide) {
		Debug.Log ("Collided");
		transform.parent.gameObject.GetComponent<Player>().setJumping (false);
	}
}
