using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public KeyCode up = KeyCode.UpArrow, down = KeyCode.DownArrow,
		left = KeyCode.LeftArrow, right = KeyCode.RightArrow;
	private KeyCode mostRecentDirection = KeyCode.None;
	public bool goingLeft, goingRight, goingUp, goingDown;
	//public float jumpHeight = 1F;
	public bool facingRight;

	// velocity per frame
	private float jumpForce = 10F;
	private float velocity = 5F;

	private Animator animator;
	private Sprite returnSprite;
	public bool jumping = false;
	//public AudioClip damageSound;
	// change this back to false later
	public static bool gameStart = true;
	public string resName;
	private int health;
	public float coolDownTime = 3;
	private float damagedElapsed;
	private int coins = 0;
	private bool invulnerable = false;
	private bool isShopOpen = false;

	// Use this for initialization
	void Start () {
		health = 100;
		//animator = GetComponent<Animator> ();
		//animator.enabled = false;
		damagedElapsed = coolDownTime;
		returnSprite = GetComponent<SpriteRenderer> ().sprite;
	}

	// Update is called once per frame
	void Update () {
		if (damagedElapsed < coolDownTime)
			damagedElapsed += Time.deltaTime;
		Vector3 newPos = this.transform.position;

		if (Player.gameStart) {
			if (Input.GetKeyDown (left)) {
				mostRecentDirection = left;
				setSpriteDir (false);
				facingRight = false;
				goingLeft = true;
			} else if (Input.GetKeyUp (left)) {
				goingLeft = false;
			} else if (Input.GetKeyDown (right)) {
				mostRecentDirection = right;
				setSpriteDir (true);
				facingRight = true;
				goingRight = true;
			} else if (Input.GetKeyUp (right)) {
				goingRight = false;
			}

			if (Input.GetKeyDown (up) && !jumping) {
				jumping = true;
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			}

			if (mostRecentDirection == left && goingLeft) {
				//animator.enabled = !jumping;
				if (jumping)
					;//GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (resName);
				float diff = velocity * Time.deltaTime;
				newPos.x -= diff;
			} else if (mostRecentDirection == right && goingRight) {
				//animator.enabled = !jumping;
				if (jumping)
					;//GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (resName);
				float diff = velocity * Time.deltaTime;
				newPos.x += diff;
			} else {
				//animator.enabled = false;
				if (jumping)
					;//GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (resName);
				else
					;//GetComponent<SpriteRenderer> ().sprite = returnSprite;
			}
			this.transform.position = newPos;
		}
	}
	public bool isFacingRight() {
		return facingRight;
	}
	public void setSpriteDir(bool right) {
		Vector3 scaling = this.transform.localScale;
		if (right && scaling.x > 0)
			scaling.x *= -1;
		else if (!right && scaling.x < 0)
			scaling.x *= -1;
		this.transform.localScale = scaling;
	}
	/*public void OnCollisionEnter2D(Collision2D collide) {
		if (collide.gameObject.tag == "ground")
			jumping = false;
		//Debug.Log (collide.gameObject.name);
	}*/
	public void setJumping(bool status) {
		jumping = false;
	}

	public void setJumpForce(float force) {
		jumpForce = force;
	}

	public float getJumpForce() {
		return jumpForce;
	}

	public void setSpeed(float s) {
		velocity = s;
	}

	public float getSpeed() {
		return velocity;
	}

	public void setHealth(int h) {
		health = h;
	}

	public int getHealth() {
		return health;
	}

	public void setInvulnerable(bool invul) {
		invulnerable = invul;
	}

	public void OnCollisionEnter2D(Collision2D collide) {
		if (collide.gameObject.tag == "hazard") {
			takeDamage ();
		}
	}

	public void OnTriggerEnter2D(Collider2D collide) {
		jumping = false;
	}

	private void takeDamage() {
		if (damagedElapsed > coolDownTime && !invulnerable) {
			health -= 10;
			if (health <= 0) {
				// TODO deal w/ death
			}
			damagedElapsed = 0;
		}
	}

	public void gainCoin() {
		coins++;
	}

	public bool IsShopOpen
	{
		get { return isShopOpen; }
		set { isShopOpen = value; }
	}
}
