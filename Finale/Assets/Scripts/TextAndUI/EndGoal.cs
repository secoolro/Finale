using UnityEngine;
using System.Collections;

public class EndGoal : MonoBehaviour {

	private float distGone;

	// Use this for initialization
	void Start () {
		distGone = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (distGone < 90f) {
			distGone += 150f * Time.deltaTime;
			transform.Translate (0f, -150f * Time.deltaTime, 0f);
		}
	}
}
