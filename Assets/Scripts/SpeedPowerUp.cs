using UnityEngine;
using System.Collections;

public class SpeedPowerUp : PowerUp {
	// adjust parameters as needed
	private float speedMultiplier = 1.5F;
	private float maxTime = 5F;
	private float elapsedTime = 0;
	private bool startAltering = false;
	float oldSpeed;

	override public void alter () {
		Destroy (this.GetComponent<Collider2D> ());
		Destroy (this.GetComponent<SpriteRenderer> ());
		startAltering = true;
		oldSpeed = player.getSpeed();
		player.setSpeed (oldSpeed * speedMultiplier);
		this.GetComponent<AudioSource> ().Play ();
		playerObj.transform.GetChild (2).GetComponent<SpriteRenderer> ().color = Color.yellow;
		playerObj.transform.GetChild (2).GetComponent<SpriteRenderer> ().enabled = true;
	}

	void Update() {
		if(startAltering)
			elapsedTime += Time.deltaTime;
		if (elapsedTime >= maxTime) {
			player.setSpeed (oldSpeed);
			playerObj.transform.GetChild (2).GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (this.gameObject);
		}
	}
}
