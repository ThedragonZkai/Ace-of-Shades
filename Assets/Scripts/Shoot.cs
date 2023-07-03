using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject bullet;
	public GameObject barrel;
	public float force;
	public AudioSource shootSound;
	public ParticleSystem muzzleFlashParticle;
	public int amountOfBullets = 1;
	public float spread = 0;
	public float BulletDamage = 1;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Action()
	{
		muzzleFlashParticle.Play();
		for (int i = 0; i < amountOfBullets; i++)
		{
			GameObject bul_ = Instantiate(bullet);
			shootSound.Play();
			bul_.transform.position = barrel.transform.position;
			// bul_.transform.localRotation = barrel.transform.rotation;
			bul_.transform.Rotate(new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread)));
			bul_.transform.localEulerAngles = new Vector3(barrel.transform.eulerAngles.x + Random.Range(-spread, spread), barrel.transform.eulerAngles.y + Random.Range(-spread, spread), barrel.transform.eulerAngles.z + Random.Range(-spread, spread));
			bul_.GetComponent<Rigidbody>().AddRelativeForce(bul_.transform.forward * force, ForceMode.Impulse);
			bul_.SendMessage("SetDamage",BulletDamage);
		}
	}
}
