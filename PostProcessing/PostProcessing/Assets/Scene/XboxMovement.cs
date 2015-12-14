using UnityEngine;
using System.Collections;

public class XboxMovement : MonoBehaviour {
	
	private Vector3 movementVector;
	private float movementSpeed = 3;
	private float jumpPower = 300;
	private float rotationSpeed = 180;
	private Rigidbody rb;
	private bool isGrounded;

	
	
	void Start() { 
		
		rb = GetComponent<Rigidbody>();
	}
	
	
	void Rotate() { 
		float rightX = Input.GetAxis("RightJoystickX");
		if (rightX < 0) {
			transform.Rotate (Vector3.up * Time.deltaTime * -rotationSpeed * -rightX);
			//Debug.Log(rightX);
		}
		if (rightX > 0) {
			transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed * rightX);
			//Debug.Log(rightX);
		}


	}

	void Move(){
		float forwardY = Input.GetAxis ("LeftJoystickY") * movementSpeed;
		float forwardX = Input.GetAxis ("LeftJoystickX") * movementSpeed;

		if (forwardY < 0) { 
			transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * -forwardY);
		}
		if (forwardY > 0) {
			transform.Translate (Vector3.back * Time.deltaTime * movementSpeed * forwardY);
		}
		if (forwardX > 0) { 
			transform.Translate (Vector3.right * Time.deltaTime * movementSpeed * forwardX);
		}
		if (forwardX < 0) { 
			transform.Translate (Vector3.left * Time.deltaTime * movementSpeed * -forwardX);
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
		
		movementVector.y = 0;

		if (Input.GetButtonDown ("A") && isGrounded) { 
			rb.AddForce(transform.up * jumpPower);
			//Debug.Log (isGrounded);
			isGrounded = false;
		}
			
		if (Input.GetButtonDown ("B")) { 
			Application.LoadLevel("xboxtest");
		}
		


		
		
	}
}
