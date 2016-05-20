using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;

	public GameObject goalPrefab;
	public GameObject contiPrefab;
	public GameObject goalObj;
	public string nextLevel;

	private Vector3 goalPos;
	private Vector3 contiPos;

	private float timer;
	private float points;

	private float timeTillPtUp; //i.e. how much time between hitting the goal and GOAL text entering
	private bool goalTextShown;
	private bool trueEnd;

	// Use this for initialization
	void Start () {
		GlobalVars.points = 0;
		timer = 200f;
		GlobalVars.timer = (int) Mathf.Round (timer * 1.5f);

		timeTillPtUp = 3.3f;
		goalTextShown = false;
		trueEnd = false;

		goalPos = new Vector3 (goalObj.transform.position.x, 169f, -3f);
		contiPos = new Vector3 (goalObj.transform.position.x - 183f, 21, -3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!GlobalVars.ended) {
			timer -= Time.deltaTime;
			if (timer < 0f) {
				player.GetComponent<PlayerController> ().die ();
			} else {
				points = GlobalVars.points;
				GlobalVars.timer = (int)Mathf.Round (timer * 1.5f);
			}
		} else {
			if (timeTillPtUp < 1f && !goalTextShown) {
				Instantiate(goalPrefab, goalPos, Quaternion.identity);
				goalTextShown = true;
			}
			if (timeTillPtUp > 0f) {
				timeTillPtUp -= Time.deltaTime;
			} else {
				if (timer > 0f) {
					timer -= 40f * Time.deltaTime;
					GlobalVars.timer = (int) Mathf.Round (timer * 1.5f);
					points += 400f * Time.deltaTime;
					GlobalVars.points = (int) (Mathf.Round(points / 10f) * 10f);
				} else if (!trueEnd) {
					Instantiate(contiPrefab, contiPos, Quaternion.identity);
					GlobalVars.timer = 0;
					trueEnd = true;
				} else if (Input.GetMouseButtonDown(0)) {
					Application.LoadLevel(nextLevel);
				}
			}
		}
	}
}
