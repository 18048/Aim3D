using UnityEngine;
using System.Collections;

public class XboxMovement : MonoBehaviour {
	
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

	
	
	void Start() { 
		
		rb = GetComponent<Rigidbody>();
	}
	
	
	void Rotate() {
		float rightX = Input.GetAxis("RightJoystickX");
        float rightY = Input.GetAxis("RightJoystickY");

            rotationX += rightY * rotationSpeedX;
            rotationY += rightX * rotationSpeedY;

            rotationX = Mathf.Clamp(rotationX, -45, 45);

            currentRotationX = Mathf.SmoothDamp(rotationX, currentRotationX, ref vRotationX, 0.1f);
            currentRotationY = Mathf.SmoothDamp(rotationY, currentRotationY, ref vRotationY, 0.1f);

            rotationObject.transform.rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);
            transform.rotation = Quaternion.Euler(0, currentRotationY,0);
    }

	void Move(){
		float forwardY = Input.GetAxis ("LeftJoystickY") * movementSpeed;
		float forwardX = Input.GetAxis ("LeftJoystickX") * movementSpeed;

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
		if (col.gameObject.tag == "ground") {
			isGrounded = true;
		} 
	}
	
	void Update() { 

		Move ();
		Rotate ();

		if (Input.GetButtonDown ("A") && isGrounded) { 
			rb.AddForce(transform.up * jumpPower);
			isGrounded = false;
		}
			
		if (Input.GetButtonDown ("B")) { 
			Application.LoadLevel("xboxtest");
		}
	}
}
