using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToTarget : MonoBehaviour
{
	public GameObject modelToPoint;
	public GameObject target;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        modelToPoint.transform.LookAt( new Vector3(target.transform.position.x, Mathf.Lerp(target.transform.position.y, Camera.main.gameObject.transform.position.y, 0.8f),target.transform.position.z) ,Vector3.up);
    }
}
