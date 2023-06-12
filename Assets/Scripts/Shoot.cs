using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject bullet;
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
		bul_.transform.position = this.gameObject.transform.position;
		bul_.transform.rotation = this.gameObject.transform.rotation;

	}
}
