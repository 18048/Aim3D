using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
   public void OpenTheDoor()
    {
        anim.SetBool("IsOpened", true);
    }
    
	void Update () {
	
	}
}
