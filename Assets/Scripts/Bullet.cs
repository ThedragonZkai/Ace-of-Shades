using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody rb;
	Collider col;
	// Start is called before the first frame update
	void Start()
    {
rb = GetComponent<Rigidbody>();
col = GetComponent<Collider>();
	}

    // Update is called once per frame
    void Update()
    {
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponents<Shoot>().Length < 1)
		{
			if (other.gameObject.GetComponents<Bullet>().Length < 1)
			{
				if (other.gameObject.GetComponents<playerController>().Length < 1)
				{
					if (other.gameObject.GetComponents<Health>().Length < 1)
					{
						other.gameObject.SendMessage("TakeDamage", 1);
					}
					Destroy(this.gameObject);
				}
			}
		}
	}
}
