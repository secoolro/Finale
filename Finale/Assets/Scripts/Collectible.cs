﻿using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	public int pts = 500;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "Player") {
			GlobalVars.points += pts;
			Destroy(gameObject);
		}
	}

}
