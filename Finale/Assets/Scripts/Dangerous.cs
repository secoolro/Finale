using UnityEngine;
using System.Collections;

public class Dangerous : MonoBehaviour {

	public bool active;

	void Start() {
		active = true;
	}

	void OnTriggerStay2D (Collider2D c) {
		if (active) {
			if (c.gameObject.tag == "Enemy") {
				Destroy (c.gameObject);
			}
			if (c.gameObject.tag == "Player") {
				c.gameObject.GetComponent <PlayerController> ().die ();
			}
		}
	}

}
