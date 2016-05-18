﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	private Animator anim;
	private Rigidbody2D rb;
	
	public float spd = 25f;
	public float dist = 60f;
	private bool goingRight;
	private bool dead;
	private float distGone;
	private Vector3 prePos;
	
	// Use this for initialization
	void Start () {
		prePos = transform.position;
		goingRight = true;
		dead = false;
		anim = GetComponent <Animator> ();
		anim.SetBool ("isDead", false);
		rb = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (!dead) { 
		//code keeps going even after death for swaying side-to-side effect
		distGone += Mathf.Abs (transform.position.x - prePos.x);
		if (distGone > dist) {
			distGone = 0f;
			goingRight = !goingRight;
			anim.SetBool("isRight", goingRight);
		}
		if (goingRight) {
			rb.velocity = new Vector2 (spd, rb.velocity.y);
		} else {
			rb.velocity = new Vector2 (-spd, rb.velocity.y);
		}
		prePos = transform.position;
		//}
		
		if (dead && transform.position.y > 170f) {
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<PlayerController>().die();
		}
	}
	
	public void die() {
		dead = true;
		anim.SetBool ("isDead", true);
		foreach (Collider2D c in GetComponents<Collider2D>()) {
			c.enabled = false;
		}
		rb.gravityScale = 0f;
		rb.velocity = new Vector2 (0f, 24f);
		dist = 3.5f;
		spd = 6f;
		GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 0.4f);
	}
	
}