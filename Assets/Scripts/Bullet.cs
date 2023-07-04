using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody rb;
	Collider col;
	float damage = 1;
	// Start is called before the first frame update
	void Start()
    {
rb = this.gameObject.GetComponent<Rigidbody>();
col = this.gameObject.GetComponent<Collider>();
	}

    // Update is called once per frame
    void Update()
    {
	}

	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponents<Shoot>().Length < 1)
		{
			if (other.gameObject.GetComponents<Bullet>().Length < 1)
			{
				if (other.gameObject.GetComponents<playerController>().Length < 1)
				{
					if (other.gameObject.GetComponents<Health>().Length > 0)
					{
						other.gameObject.SendMessage("TakeDamage", damage);
					}
					Destroy(this.gameObject);
				}
				else {
					if (other.gameObject.GetComponents<Health>().Length > 0)
					{
						other.gameObject.SendMessage("TakeDamage", damage);
					}
					Destroy(this.gameObject);
				}
			}
		}
	}
	public void SetDamage(float damage_) {
		damage = damage_;
	}
}
