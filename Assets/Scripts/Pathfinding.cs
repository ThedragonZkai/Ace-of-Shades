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
	float randomMultiplier;
	public float DistanceToShoot;
	private float timer;
	public float timeToWait;
	// Start is called before the first frame update
	void Start()
    {
		target = GameObject.FindObjectOfType<PlayerFollow>().gameObject;
		navAgent = GetComponent<NavMeshAgent>();
		randomMultiplier = Random.Range(0.5f,1.5f);
		timer = 0;
	}

    // Update is called once per frame
    void Update()
    {
		
		timer = timer + Time.deltaTime;
		enemyModel.transform.LookAt( new Vector3(target.transform.position.x, Mathf.Lerp(target.transform.position.y, Camera.main.gameObject.transform.position.y, 0.8f),target.transform.position.z) ,Vector3.up);
		navAgent.SetDestination(target.transform.position);
		enemyModel.transform.position = new Vector3(enemyModel.transform.position.x, Mathf.Lerp(enemyModel.transform.position.y, Camera.main.gameObject.transform.position.y, lerpSpeed * randomMultiplier * Time.deltaTime), enemyModel.transform.position.z);
		if (Vector3.Distance(enemyModel.transform.position, target.transform.position) < DistanceToShoot * randomMultiplier && timer > (timeToWait * randomMultiplier)) {
			timer = 0;
			gameObject.SendMessage("ShootGun");
			randomMultiplier = Random.Range(0.5f,1.5f);
		}
		
	}
}
