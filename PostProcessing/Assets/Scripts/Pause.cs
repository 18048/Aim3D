using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	[SerializeField] private GameObject panel;
	private bool PauseCheck = false;

	// Use this for initialization
	void Start () {
		panel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (PauseCheck == false) {
			Time.timeScale = 1;
			panel.SetActive (false);

			if (Input.GetButtonDown("Start")) {
				PauseCheck = true;
			}
		}
		 else {
			Time.timeScale = 0;
			panel.SetActive (true);

			if (Input.GetButtonDown ("Start")) { 
				PauseCheck = false;
			}
		}
	}
}

