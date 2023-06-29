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
	public Finger[] fingers;
	public int grabAmount = 45;
	public Transform shadesHolder;

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

		fingers = GetComponentsInChildren<Finger>();;

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
			if (other.transform.tag == "Shades" && Input.GetButtonDown("XRI_" + side + "_GripButton"))
			{
				other.GetComponent<Collider>().enabled = false;
				other.GetComponent<Spin>().enabled = false;
				other.transform.SetParent(shadesHolder);
				other.transform.localPosition = new Vector3(0,0,0);
				other.transform.localEulerAngles = new Vector3(0,0,0);
				other.transform.localScale = new Vector3(1,1,1);
				GameObject.FindObjectOfType<GameController>().SendMessage("Shades Pickup");
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
		foreach (Finger f in fingers) {
			f.transform.localEulerAngles = new Vector3(Input.GetAxis("XRI_" + side + "_Grip") * grabAmount,0,0);
		}



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

		if (touchingObj != null)
		{

			if ((Input.GetButtonDown("XRI_" + side + "_GripButton")) || Input.GetMouseButtonDown(mouseB))
			{
				if (touchingObj.transform.tag == "Interactable")
				{

					Debug.Log("trigger pulled");
					holdingObj = touchingObj;
					isHolding = true;
					holdingObj.GetComponent<Rigidbody>().isKinematic = true;
					Collider[] allColliders = holdingObj.GetComponentsInChildren<Collider>();
					foreach (Collider col in allColliders)
					{
						col.enabled = false;
					}
					visuals.SetActive(false);
					holdingObj.transform.SetParent(this.gameObject.transform, true);
					holdingObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
					holdingObj.transform.localPosition = new Vector3(0, 0, 0);
					holdingObj.transform.localEulerAngles = rotationAdd;

				}
			}

			if ((Input.GetButtonUp("XRI_" + side + "_GripButton")) || Input.GetMouseButtonUp(mouseB))
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
				
				touchingObj = null;
				holdingObj = null;
				isHolding = false;
				visuals.SetActive(true);
			}

			

			if ((Input.GetAxis("XRI_" + side + "_Trigger") > 0.80 && lastTriggerPull < 0.80) || Input.GetButtonDown("XRI_" + side + "_Trigger") || Input.GetKeyDown(KeyCode.Space)) {
				holdingObj.SendMessage("Action");
				Debug.Log("sent action message");
			}

		}

		lastTriggerPull = Input.GetAxis("XRI_" + side + "_Trigger");
		lastWorldPos = transform.position;
		lastWorldRot = transform.rotation.eulerAngles;
	}

}
