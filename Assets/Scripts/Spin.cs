using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
	public GameObject objToSpin;
	public bool doRandomizeSpeed = true;
	private float rotateMultiplierXrand = 1;
	private float rotateMultiplierYrand = 1;
	private float rotateMultiplierZrand = 1;
	public float XMultiplier = 1;
	public float YMultiplier = 1;
	public float ZMultiplier = 1;
	// Start is called before the first frame update
	void Start()
    {
		if (doRandomizeSpeed)
		{
			rotateMultiplierXrand = Random.Range(-1.0f, 1.0f);
			rotateMultiplierYrand = Random.Range(-1.0f, 1.0f);
			rotateMultiplierZrand = Random.Range(-1.0f, 1.0f);
		}
	}

    // Update is called once per frame
    void Update()
    {
		objToSpin.transform.Rotate(new Vector3(XMultiplier * rotateMultiplierXrand,YMultiplier *rotateMultiplierYrand,ZMultiplier * rotateMultiplierZrand),Space.Self);
	}
}
