using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public GameObject stripesL;
	public GameObject stripesR;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "Player") {
			//Time.timeScale = 0f;
			Instantiate(stripesL, new Vector3 (transform.position.x - 246f, 116f, -2f), Quaternion.identity);
			Instantiate(stripesR, new Vector3 (transform.position.x + 246f, 140f, -2f), Quaternion.identity);
			GlobalVars.ended = true;
		}
	}
}
