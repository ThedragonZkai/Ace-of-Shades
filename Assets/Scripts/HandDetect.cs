using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDetect : MonoBehaviour
{
	Collider col;
	bool isHolding = false;
	GameObject holdingObj;
	string side;
	GameObject touchingObj;
	public GameObject visuals;
	public Vector3 rotationAdd;
	Rigidbody rb;
	float lastTriggerPull;
	Vector3 lastWorldPos;
	Vector3 lastWorldRot;
	public int forceAmplifier;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		col = GetComponent<Collider>();
		if (gameObject.name.ToLower().Contains("left"))
		{
			side = "Left";
		}
		else
		{
			side = "Right";
		}
	}

	// Update is called once per frame
	void OnTriggerStay(Collider other)
	{
		if (other.isTrigger == true)
		{
			if (other.transform.tag == "Interactable")
			{
				touchingObj = other.transform.gameObject;
			}
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.transform.tag == "Interactable")
		{
			touchingObj = null;
		}
	}

	void Update()
	{
		if (isHolding == true) {
			holdingObj.transform.localPosition = new Vector3(0, 0, 0);
			holdingObj.transform.localEulerAngles = rotationAdd;
		}

		int mouseB;
		if (side == "Left") {
			mouseB = 0;
		}
		else {
			mouseB = 1;
		}

		Debug.Log(touchingObj);
		if (touchingObj != null)
		{

			if ((Input.GetAxis("XRI_" + side + "_Trigger") > 0 && lastTriggerPull == 0) || Input.GetMouseButtonDown(mouseB))
			{
				Collider[] allColliders = holdingObj.GetComponentsInChildren<Collider>();
				foreach (Collider col in allColliders) {
					col.enabled = false;
				}


				Debug.Log("trigger pulled");
				holdingObj = touchingObj;
				isHolding = true;
				holdingObj.GetComponent<Rigidbody>().isKinematic = true;
				visuals.SetActive(false);
				holdingObj.transform.SetParent(this.gameObject.transform, true);
				holdingObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
				holdingObj.transform.localPosition = new Vector3(0, 0, 0);
				holdingObj.transform.localEulerAngles = rotationAdd;

			}
	
			if ((Input.GetAxis("XRI_" + side + "_Trigger") == 0 && lastTriggerPull != 0) || Input.GetMouseButtonUp(mouseB))
			{
				Collider[] allColliders = holdingObj.GetComponentsInChildren<Collider>();
				foreach (Collider col in allColliders) {
					col.enabled = true;
				}


				holdingObj.GetComponent<Rigidbody>().isKinematic = false;
				holdingObj.transform.SetParent(null, true);
				touchingObj.transform.position = transform.position;
				holdingObj.GetComponent<Rigidbody>().AddForce((transform.position - lastWorldPos) * forceAmplifier, ForceMode.Impulse);
				holdingObj.GetComponent<Rigidbody>().AddTorque((transform.rotation.eulerAngles - lastWorldRot) * forceAmplifier, ForceMode.Impulse);
				Debug.Log((transform.rotation.eulerAngles - lastWorldRot) * forceAmplifier);
				
				touchingObj = null;
				holdingObj = null;
				isHolding = false;
				visuals.SetActive(true);
			}

			if (Input.GetAxis("XRI_" + side + "_Trigger") == 1 && lastTriggerPull < 1) {
				holdingObj.SendMessage("Action");
			}

		}

		lastTriggerPull = Input.GetAxis("XRI_" + side + "_Trigger");
		lastWorldPos = transform.position;
		lastWorldRot = transform.rotation.eulerAngles;
	}

}
