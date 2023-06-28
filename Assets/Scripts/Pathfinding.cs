using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Pathfinding : MonoBehaviour
{
	public NavMeshAgent navAgent;
	private GameObject target;
	public GameObject enemyModel;
	public float lerpSpeed;
	// Start is called before the first frame update
	void Start()
    {
		target = GameObject.FindObjectOfType<playerController>().gameObject;
		navAgent = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
		navAgent.SetDestination(target.transform.position);
		enemyModel.transform.position = new Vector3(enemyModel.transform.position.x, Mathf.Lerp(enemyModel.transform.position.y, Camera.main.gameObject.transform.position.y, lerpSpeed * Time.deltaTime), enemyModel.transform.position.z);
	}
}
