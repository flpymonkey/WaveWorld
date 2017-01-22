using UnityEngine;
using System.Collections;

public class JumpPowerUp : PowerUp {
	// adjust parameters as needed
	//private float jumpForce = 5F;
	private float jumpMultiplier = 1.5F;
	private float maxTime = 5F;
	private float elapsedTime = 0;
	private bool startAltering = false;
	float oldJumpForce;

	void Start() {
		GetComponent<Animator> ().speed = .2F;
	}

	override public void alter () {
		Destroy (this.GetComponent<Collider2D> ());
		Destroy (this.GetComponent<SpriteRenderer> ());
		startAltering = true;
		oldJumpForce = player.getJumpForce();
		player.setJumpForce (oldJumpForce * jumpMultiplier);
		this.GetComponent<AudioSource> ().Play ();
		playerObj.transform.GetChild (1).GetComponent<SpriteRenderer> ().color = Color.magenta;
		playerObj.transform.GetChild (1).GetComponent<SpriteRenderer> ().enabled = true;
	}

	void Update() {
		if(startAltering)
			elapsedTime += Time.deltaTime;
		if (elapsedTime >= maxTime) {
			player.setJumpForce (oldJumpForce);
			playerObj.transform.GetChild (1).GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (this.gameObject);
		}
	}
}
