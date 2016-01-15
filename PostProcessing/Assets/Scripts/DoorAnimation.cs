using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {

    private Animator anim;
    private AudioSource source;
    public bool isOpen = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
	}
	
    IEnumerator WaitForSound(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        source.Play();
    }

	// Update is called once per frame
   public void OpenTheDoor()
    {
        anim.SetBool("IsOpened", true);
        StartCoroutine(WaitForSound(0.5f));
        isOpen = true;
    }
}
