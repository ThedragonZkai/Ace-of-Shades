using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public GameObject enemy;
	private float timer;
	public float timeToWait;
	public float heightToSpawnAt;
	public float distanceTillSpawn;
	private float randomMultiplier;
	private GameObject player;
	public int AmountOfSpawnsBeforeLevelUp;
	GameController gameController;
	// Start is called before the first frame update
	void Start()
    {
		gameController = GameObject.FindObjectOfType<GameController>();
		randomMultiplier = Random.Range(0.2f, 1.2f);
		player = FindObjectOfType<playerController>().gameObject;
	}

    // Update is called once per frame
    void Update()
    {
		timer = timer + Time.deltaTime;
		if (timer > timeToWait * randomMultiplier && Vector3.Distance(player.transform.position, this.transform.position) < distanceTillSpawn && AmountOfSpawnsBeforeLevelUp > 0) {
			GameObject e = Instantiate(enemy, this.transform);
			GameObject em = e.GetComponent<Pathfinding>().enemyModel;
			em.transform.position = new Vector3(em.transform.position.x,heightToSpawnAt,em.transform.position.z);
			timer = 0;
			AmountOfSpawnsBeforeLevelUp = AmountOfSpawnsBeforeLevelUp - 1;
		}
	}
}
