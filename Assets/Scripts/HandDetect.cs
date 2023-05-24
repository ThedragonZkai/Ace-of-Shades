using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDetect : MonoBehaviour
{
	Collider col;
	bool isHolding = false;
	GameObject holdingObj;
	string side;
	// Start is called before the first frame update
	void Start()
    {
		col = GetComponent<Collider>();
		if (gameObject.name.ToLower().Contains("left")) {
			side = "Left";
		}
		else {
			side = "Right";
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (isHolding) {
			holdingObj.transform.position = this.gameObject.transform.position;
		}

        if (Input.GetButtonDown("XRI_" + side + "_Trigger") || Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("trigger pulled");
		
			void OnCollisionEnter(Collision other)
			{
				if (other.transform.tag == "Interactable")
				{
					holdingObj = other.gameObject;
					isHolding = true;
				}
			}
		}
		if (Input.GetButtonUp("XRI_" + side + "_Trigger") || Input.GetKeyUp(KeyCode.Space)) {
			holdingObj = null;
			isHolding = false;
		}
	}
}
