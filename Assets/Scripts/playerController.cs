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
		Vector3 moveX = cam.transform.right * Input.GetAxis("Horizontal") * speed;
		Vector3 moveZ = cam.transform.forward * Input.GetAxis("Vertical") * speed;
		// Vector3 dragX = cam.transform.right * rb.velocity.x * speed * drag;
		// Vector3 dragY = cam.transform.forward * rb.velocity.z * speed * drag;

		rb.AddForce(moveX, ForceMode.Impulse);
		rb.AddForce(moveZ, ForceMode.Impulse);
		// rb.AddForce(dragX);
		// rb.AddForce(dragY);		
	}
}
