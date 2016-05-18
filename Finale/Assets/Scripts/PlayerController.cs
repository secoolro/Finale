using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float spd;
	public float jumppower;

	public float deathY = -60f;

	private Vector3 reflect = new Vector3 (-1f, 1f, 1f);
	private Vector3 regular = new Vector3 (1f, 1f, 1f);

	private Rigidbody2D rb;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.velocity = new Vector2 (spd, rb.velocity.y);
			anim.SetBool ("Moving", true);
			transform.localScale = regular;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity = new Vector2 (-spd, rb.velocity.y);
			anim.SetBool ("Moving", true);
			transform.localScale = reflect;
		} else {
			rb.velocity = new Vector2(0f, rb.velocity.y);
			anim.SetBool ("Moving", false);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && Mathf.Abs(rb.velocity.y) < 0.1f ) {
			rb.velocity = new Vector2(rb.velocity.x, jumppower);
		}

		if (transform.position.y < deathY) {
			die ();
		}
	}

	public void die() {
		Application.LoadLevel ("Finale");
	}
}
