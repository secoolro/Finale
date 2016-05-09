using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float spd;
	
	private Rigidbody2D rb;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.velocity = new Vector2 (spd, rb.velocity.y);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity = new Vector2 (-spd, rb.velocity.y);
		} else {
			rb.velocity = new Vector2(0f, rb.velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && Mathf.Abs(rb.velocity.y) < 0.01f ) {
			rb.velocity = new Vector2(rb.velocity.x, 100f);
		}
	}
}
