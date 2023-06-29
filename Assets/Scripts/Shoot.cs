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
	public int amountOfbullets = 1;
	public float spread = 0;
	// Start is called before the first frame update
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Action() {
		muzzleFlashParticle.Play();
		for (int i = 0; i < amountOfbullets; i++)
		{
			GameObject bul_ = Instantiate(bullet);
			shootSound.Play();
			bul_.transform.position = barrel.transform.position;
			bul_.transform.rotation = barrel.transform.rotation;
			bullet.transform.Rotate(new Vector3(Random.Range(-spread, spread),Random.Range(-spread, spread),Random.Range(-spread, spread)));
			bul_.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * force, ForceMode.Impulse);
		}
	}
}
