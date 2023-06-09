using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	Rigidbody rb;
	Collider col;
	public float speed;
	public float drag;
	Camera cam;
	public float jumpForce;
	bool isGrounded = false;
	float rotateBy;
	public float rotateAmount;
	float lastRightPrimaryXValue;

	// Start is called before the first frame update
	void Start()
    {
		col = GetComponent<Collider>();
		rb = GetComponent<Rigidbody>();
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{

		
		Vector3 moveX = new Vector3(cam.transform.right.normalized.x, 0, cam.transform.right.normalized.z) * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		Vector3 moveZ = new Vector3(cam.transform.forward.normalized.x, 0, cam.transform.forward.normalized.z) * Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float dragX = rb.velocity.x * speed * drag * Time.deltaTime;
		float dragZ = rb.velocity.z * speed * drag * Time.deltaTime;

		rb.AddForce(moveX, ForceMode.Impulse);
		rb.AddForce(moveZ, ForceMode.Impulse);
		rb.AddForce(new Vector3(-dragX, 0, -dragZ));

		if (isGrounded)
		{
			if (Input.GetButtonDown("XRI_Right_PrimaryButton") || Input.GetKeyDown(KeyCode.Z))
			{
				rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
				isGrounded = false;
			}
		}
		if ((Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal") > 0.8 && lastRightPrimaryXValue < 0.8) || Input.GetKeyDown(KeyCode.RightArrow)) {
			
			// rotateBy += rotateAmount;
			transform.Rotate(new Vector3(0, rotateAmount, 0));
		}
		if ((Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal") < -0.8 && lastRightPrimaryXValue > -0.8) || Input.GetKeyDown(KeyCode.LeftArrow)) {
			
			// rotateBy -= rotateAmount;
			transform.Rotate(new Vector3(0, -rotateAmount, 0));
		}



		lastRightPrimaryXValue = Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal");
	}
	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.layer == 3) {
			isGrounded = false;
		}
	}
	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.layer == 3) {
			isGrounded = true;
		}	
	}


}
