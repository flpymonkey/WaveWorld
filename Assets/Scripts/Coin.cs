using UnityEngine;
using System.Collections;

public class Coin : PowerUp {
	private bool started = false;
	override public void alter() {
		player.gainCoin ();
		Destroy (this.GetComponent<Collider2D> ());
		Destroy (this.GetComponent<SpriteRenderer> ());
		this.GetComponent<AudioSource> ().Play ();
		started = true;
	}
	public void Update() {
		if(!this.GetComponent<AudioSource>().isPlaying && started)
			Destroy (this.gameObject);
	}
}
