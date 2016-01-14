using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Raycast : MonoBehaviour {

    Camera camera;
   // DoorAnimation doorAnim;
    [SerializeField]private Image image;
    [SerializeField]private float range;
    RaycastHit hit;
    private bool seeDoor = false;
    public bool sesamOpenU = false;


    // Use this for initialization
    void Start () {
        camera = GetComponentInChildren<Camera>();
	}

    void OpenDoor()
    {
        if (Input.GetButtonDown(Tags.xboxX))
        {
            hit.collider.gameObject.GetComponentInParent<DoorAnimation>().OpenTheDoor();
            // doorAnim.OpenTheDoor();
            //Debug.Log(doorAnim);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.name == "pCube455" && hit.collider != null)
            {
                seeDoor = true;
                OpenDoor();
            }
        }
        else
            seeDoor = false;

        if (seeDoor)
        {
            image.enabled = true;
        }
        else
            image.enabled = false;
	}
}
