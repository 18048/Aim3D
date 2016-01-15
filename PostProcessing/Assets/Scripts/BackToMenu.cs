using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {

	void Update () {
        if (Input.GetButtonDown(Tags.xboxB))
        {
            Application.LoadLevel("MainMenu");
        }
	}
}
