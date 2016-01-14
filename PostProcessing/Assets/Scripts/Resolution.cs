using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("width" + Screen.width + "height" + Screen.height);
        Screen.SetResolution(780, 130, false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
