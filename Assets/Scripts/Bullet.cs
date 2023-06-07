using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody rb;
	Collider col;
	public float force;
	// Start is called before the first frame update
	void Start()
    {
rb = GetComponent<Rigidbody>();
col = GetComponent<Collider>();
rb.AddForce(new Vector3(0,0,force), ForceMode.Impulse);
	}

    // Update is called once per frame
    void Update()
    {
		rb.AddForce(new Vector3(0,0,force));
	}

	void OnCollisionEnter(Collision other)
	{
		
	}
}
