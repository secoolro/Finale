using UnityEngine;
using System.Collections;

public class MoveOnce : MonoBehaviour {

	public float dist;
	public float spd;

	private float distGone;

	// Use this for initialization
	void Start () {
		distGone = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (distGone < dist) {
			distGone += Mathf.Abs(spd * Time.deltaTime);
			transform.Translate(spd * Time.deltaTime, 0f, 0f);
		}
	}
}
