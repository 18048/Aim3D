using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Raycast : MonoBehaviour {

    EnemyFollow enemyFollow;
    [SerializeField]private Transform enemy;
    Camera camera;
    [SerializeField]private Image image;
    [SerializeField]private float range;
    RaycastHit hit;
    private bool seeDoor = false;

    // Use this for initialization
    void Start () {
        camera = GetComponentInChildren<Camera>();
        enemyFollow = enemy.GetComponent<EnemyFollow>();
	}

    void OpenDoor()
    {
        if (Input.GetButtonDown(Tags.xboxX))
        {
            hit.collider.gameObject.GetComponentInParent<DoorAnimation>().OpenTheDoor();
        }
    }

    IEnumerator WaitForVictory(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel("VictoryScreen");
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
                if (hit.collider.tag == "EnemyDoor")
                {
                    enemyFollow.mustFollow = true;
                }
                if(hit.collider.tag == "VictoryDoor")
                {
                    StartCoroutine(WaitForVictory(1.75f));
                }
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
