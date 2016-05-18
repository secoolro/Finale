using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float spd;
	public float jumppower;
	
	private bool canjump;
	
	public float deathY = -60f;
	private bool dead;
	
	private Vector3 reflect = new Vector3 (-1f, 1f, 1f);
	private Vector3 regular = new Vector3 (1f, 1f, 1f);

	private Rigidbody2D rb;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		dead = false;
		rb = GetComponent <Rigidbody2D> ();
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead) {
			if (Input.GetKey (KeyCode.D)) {
				rb.velocity = new Vector2 (spd, rb.velocity.y);
				anim.SetBool ("Moving", true);
				transform.localScale = regular;
			} else if (Input.GetKey (KeyCode.A)) {
				rb.velocity = new Vector2 (-spd, rb.velocity.y);
				anim.SetBool ("Moving", true);
				transform.localScale = reflect;
			} else {
				rb.velocity = new Vector2 (0f, rb.velocity.y);
				anim.SetBool ("Moving", false);
			}
			//jump = Mathf.Abs (rb.velocity.y) < 0.1f;
			if (Input.GetKeyDown (KeyCode.W) && canjump) {
				rb.velocity = new Vector2 (rb.velocity.x, jumppower);
			}
			
			if (transform.position.y < deathY) {
				die ();
			}
		} else {
			if (transform.position.y < deathY - 10f) {
				Application.LoadLevel ("Finale");
			}
		}
	}
	
	void OnTriggerStay2D(Collider2D c) {
		canjump = true;
	}
	
	void OnTriggerExit2D(Collider2D c) {
		canjump = false;
	}
	
	public void die() {
		if (!dead) {
			foreach (Collider2D c in GetComponents<Collider2D>()) {
				c.enabled = false;
			}
			rb.fixedAngle = false;
			rb.velocity = new Vector2(0f, 0f);
			rb.AddForce (new Vector2 (0f, 200f), ForceMode2D.Impulse);
			rb.AddTorque (90f);
			dead = true;
		}
	}
}
