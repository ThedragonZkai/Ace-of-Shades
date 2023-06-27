using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceClip : MonoBehaviour
{
	GameObject player;
	public int distanceToStartClipping;
	public GameObject[] clipObjects;
	

	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.FindObjectOfType<playerController>().gameObject;
	}

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in clipObjects) {
			if (Vector3.Distance(player.transform.position, obj.transform.position) > distanceToStartClipping) {
				obj.SetActive(false);
			}
			else {
				obj.SetActive(true);
			}
		}

    }
}
