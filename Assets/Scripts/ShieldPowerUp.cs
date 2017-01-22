using UnityEngine;
using System.Collections;

public class ShieldPowerUp : PowerUp {
	private float maxTime = 5F;
	private float elapsedTime = 0;
	private bool startAltering = false;

	override public void alter() {
		Destroy (this.GetComponent<Collider2D> ());
		Destroy (this.GetComponent<SpriteRenderer> ());
		startAltering = true;
		player.setInvulnerable (true);
		this.GetComponent<AudioSource> ().Play ();
		playerObj.transform.GetChild (0).GetComponent<SpriteRenderer> ().color = Color.cyan;
		playerObj.transform.GetChild (0).GetComponent<SpriteRenderer> ().enabled = true;
	}

	void Update() {
		if(startAltering)
			elapsedTime += Time.deltaTime;
		if (elapsedTime >= maxTime) {
			player.setInvulnerable (false);
			playerObj.transform.GetChild (0).GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (this.gameObject);
		}
	}
}
