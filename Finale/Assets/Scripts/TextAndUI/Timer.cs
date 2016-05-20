using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	
	private Text t;
	
	// Use this for initialization
	void Start () {
		GlobalVars.ended = false;
		t = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		t.text = "TIME: " + GlobalVars.timer;
	}
}
