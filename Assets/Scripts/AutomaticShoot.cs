using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShoot : MonoBehaviour
{
	Shoot shoot;
	public GameObject target;

	float randomMultiplier;
	public float DistanceToShoot;
	private float timer;
	public float timeToWait;
	public float bulletsToFireEachTime;
	private float bulletsFired;
	public float delay;
	// Start is called before the first frame update
	void Start()
    {
		randomMultiplier = Random.Range(0.5f,1.5f);
		shoot = GetComponentInChildren<Shoot>();
		bulletsFired = 0;
	}

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
		if (bulletsFired > 0 && timer > delay) {
			bulletsFired -= 1;
			shoot.SendMessage("ShootGun");
			timer = 0;
		}
		timer = timer + Time.deltaTime;
		if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) < DistanceToShoot * randomMultiplier && timer > (timeToWait * randomMultiplier)) {
			Debug.Log("Boss shooting");
			bulletsFired = bulletsToFireEachTime;
			randomMultiplier = Random.Range(0.5f,1.5f);
		}
    }
}
