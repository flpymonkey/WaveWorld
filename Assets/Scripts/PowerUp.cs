using UnityEngine;
using System.Collections;

abstract public class PowerUp : MonoBehaviour {
	public Player player;
	public GameObject playerObj;
	public void OnTriggerEnter2D(Collider2D collide) {
		Debug.Log ("PowerUp Hit");
		playerObj = collide.gameObject;
		Player play = playerObj.GetComponent<Player> ();
		Debug.Log (play);
		if (play != null) {
			Debug.Log ("Player Hit PowerUp");
			player = play;
			alter ();
		}
	}
	abstract public void alter ();
}
