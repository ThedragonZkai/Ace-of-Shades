using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
	public GameObject objToSpin;
	public float rotateAmount;
	private float rotateMultiplierX;
	private float rotateMultiplierY;
	private float rotateMultiplierZ;
	// Start is called before the first frame update
	void Start()
    {
        rotateMultiplierX = Random.Range(0.5f,1.5f);
		rotateMultiplierY = Random.Range(0.5f,1.5f);
		rotateMultiplierZ = Random.Range(0.5f,1.5f);

	}

    // Update is called once per frame
    void Update()
    {
		objToSpin.transform.Rotate(new Vector3(rotateAmount * rotateMultiplierX,rotateAmount *rotateMultiplierY,rotateAmount * rotateMultiplierZ));
	}
}
