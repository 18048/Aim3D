using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XboxMovement : MonoBehaviour {

    private EnemyFollow enemyFollow;
    Text text;

    [SerializeField]private Text combatText;
    [SerializeField]private Transform enemy;
	private Vector3 movementVector;
	private float movementSpeed = 3;
	private float jumpPower = 300;
	private float rotationSpeedY = 2.85f;
	private Rigidbody rb;
	private bool isGrounded;
    [SerializeField]private GameObject rotationObject;
    private float rotationX;
    private float vRotationX;
    private float currentRotationX;
    private float rotationY;
    private float vRotationY;
    private float currentRotationY;
    private float rotationSpeedX = 2f;
    private bool isFighting = false;
    private float timeRemaining = 4f;
    private int yClick = 0;
    [SerializeField]private int clicksToEscape = 25;



    void Start() {

        enemyFollow = enemy.GetComponent<EnemyFollow>();
		rb = GetComponent<Rigidbody>();
        text = combatText.GetComponentInChildren<Text>();
    }
    
    IEnumerator WaitForReset(float time)
    {
        yield return new WaitForSeconds(time);
        yClick = 0;
        timeRemaining = 4;
        combatText.text = "";
    }

    void FightEnemy()
    {
        if (timeRemaining > 0)
        {
            combatText.text = yClick + " / " + clicksToEscape;
            timeRemaining -= Time.deltaTime;
            if (Input.GetButtonDown(Tags.xboxY))
            {
                if (yClick < clicksToEscape)
                {
                    yClick++;
                }
            }
        }

        if(timeRemaining <= 0 && yClick >= clicksToEscape)
        {
            isFighting = false;
            enemyFollow.rotateCam = false;
            Debug.Log("ggwp");
            StartCoroutine(WaitForReset(2f));
        } else if(timeRemaining <= 0 && yClick < clicksToEscape)
        {
            Debug.Log("rekt noob");
        }
    }

	void CheckIfEnemy()
    {
        if (enemyFollow.rotateCam)
        {
            isFighting = true;
            rotationObject.transform.LookAt(enemy);
            FightEnemy();
        }
    }

	void Rotate() {
		float rightX = Input.GetAxis(Tags.RightJoystickX);
        float rightY = Input.GetAxis(Tags.RightJoystickY);

            rotationX += rightY * rotationSpeedX;
            rotationY += rightX * rotationSpeedY;

            rotationX = Mathf.Clamp(rotationX, -45, 45);

            currentRotationX = Mathf.SmoothDamp(rotationX, currentRotationX, ref vRotationX, 0.1f);
            currentRotationY = Mathf.SmoothDamp(rotationY, currentRotationY, ref vRotationY, 0.1f);

            rotationObject.transform.rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);
            transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
    }

	void Move(){
		float forwardY = Input.GetAxis (Tags.LeftJoystickY) * movementSpeed;
		float forwardX = Input.GetAxis (Tags.LeftJoystickX) * movementSpeed;

		if (forwardY < 0) { 
			transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * -forwardY, Space.Self);
		}
		if (forwardY > 0) {
			transform.Translate (Vector3.back * Time.deltaTime * movementSpeed * forwardY, Space.Self);
		}
		if (forwardX > 0) { 
			transform.Translate (Vector3.right * Time.deltaTime * movementSpeed * forwardX, Space.Self);
		}
		if (forwardX < 0) { 
			transform.Translate (Vector3.left * Time.deltaTime * movementSpeed * -forwardX, Space.Self);
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == Tags.ground) {
			isGrounded = true;
		} 
	}

    void Jump()
    {
        if (Input.GetButtonDown(Tags.xboxA))
        {
            if (isGrounded)
            {
                rb.AddForce(transform.up * jumpPower);
                isGrounded = false;
            }
        }
    }
	
	void Update() {

        if (isFighting == false)
        {
            Move();
            Rotate();
            Jump();
        }
            CheckIfEnemy();
	}
}
