using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject leftController;
	private Rigidbody LCRB;
	public float testingSpeed = 0.1f;
	public float testingRotateSpeed = 0.1f;
	bool testingMode = false;



	public Vector3 worldPosition;
	Plane plane = new Plane(Vector3.up, 0);

	// Start is called before the first frame update
	void Start()
    {
		LCRB = leftController.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.T)) {
			testingMode = true;
			Debug.Log("Testing Mode initiated");
		}


        if (Input.GetButton("XRI_Left_Trigger")) {
			Debug.Log("OMG IT WORKS");
		}

		if (testingMode) {
			if (Input.GetKey(KeyCode.W)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(0, 0, testingSpeed));
			}
			if (Input.GetKey(KeyCode.A)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(-testingSpeed, 0, 0));
			}
			if (Input.GetKey(KeyCode.S)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(0, 0, -testingSpeed));
			}
			if (Input.GetKey(KeyCode.D)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(testingSpeed, 0, 0));
			}
			if (Input.GetKey(KeyCode.E)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(0, testingSpeed, 0));
			}
			if (Input.GetKey(KeyCode.Q)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(0, -testingSpeed, 0));
			}

			float distance;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (plane.Raycast(ray, out distance))
			{
				worldPosition = ray.GetPoint(distance);
			}
			leftController.transform.LookAt(worldPosition);
		
			//make the ray come from the controller or soemthing idk


			// if (Input.GetKey(KeyCode.UpArrow)) {
			// 	leftController.transform.eulerAngles += new Vector3(-testingRotateSpeed,0,0);
			// }
			// if (Input.GetKey(KeyCode.LeftArrow)) {
			// 	leftController.transform.eulerAngles += new Vector3(0,testingRotateSpeed,0);
			// }
			// if (Input.GetKey(KeyCode.DownArrow)) {
			// 	leftController.transform.eulerAngles += new Vector3(testingRotateSpeed,0,0);
			// }
			// if (Input.GetKey(KeyCode.RightArrow)) {
			// 	leftController.transform.eulerAngles += new Vector3(0,-testingRotateSpeed,0);
			// }
		}
    }
}
