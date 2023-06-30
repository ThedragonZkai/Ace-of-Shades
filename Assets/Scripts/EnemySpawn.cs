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
	public int healthForEnemiesToSpawnAt;
	public int[] stagesToSpawnAt;
	public Vector3 enemySpawnRange;
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
		if (checkStage())
		{
			timer = timer + Time.deltaTime;
			if (timer > timeToWait * randomMultiplier && Vector3.Distance(player.transform.position, this.transform.position) < distanceTillSpawn && AmountOfSpawnsBeforeLevelUp > 0)
			{
				GameObject e = Instantiate(enemy, this.transform);
				e.transform.localPosition = new Vector3(Random.Range(-enemySpawnRange.x, enemySpawnRange.x), e.transform.localPosition.y, Random.Range(-enemySpawnRange.z, enemySpawnRange.z));
				GameObject em = e.GetComponent<Pathfinding>().enemyModel;
				e.GetComponentInChildren<Health>().gameObject.SendMessage("TakeDamage", -healthForEnemiesToSpawnAt);
				em.transform.position = new Vector3(em.transform.position.x, heightToSpawnAt, em.transform.position.z);
				timer = 0;
				AmountOfSpawnsBeforeLevelUp = AmountOfSpawnsBeforeLevelUp - 1;
			}
		}
	}
	bool checkStage() {

		foreach (int stage in stagesToSpawnAt) {
			if (stage == gameController.stage) {
				return true;
			}
		}
			return false;
	}
}
