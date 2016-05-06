using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public GameObject player;
	public float y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, y, -1f);
	}
}
