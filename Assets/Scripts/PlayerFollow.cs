using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
	GameObject player;
	public float lerpSpeed;
	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.FindObjectOfType<playerController>().gameObject;
	}

    // Update is called once per frame
    void Update()
    {
		transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * lerpSpeed);
	}
}
