using UnityEngine;
using System.Collections;

public class EndConti : MonoBehaviour {

	private float distGone;

	private Animator anim;

	// Use this for initialization
	void Start () {
		distGone = 0f;
		anim = GetComponent<Animator> ();
		anim.speed = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (distGone < 180f) {
			distGone += 180f * Time.deltaTime;
			transform.Translate (180f * Time.deltaTime, 0f, 0f);
		} else {
			anim.speed = 1f;
		}
	}
}
