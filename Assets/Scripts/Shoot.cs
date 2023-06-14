using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject bullet;
	public GameObject barrel;
	public float force;
	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Action() {
		GameObject bul_ = Instantiate(bullet);
		bul_.transform.position = barrel.transform.position;
		bul_.transform.rotation = barrel.transform.rotation;
		bul_.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * force, ForceMode.Impulse);


	}
}
