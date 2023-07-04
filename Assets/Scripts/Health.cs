using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public float health;
	public GameObject objToDestroy;
	public TMP_Text healthTextSign;
	public Slider healthSlider;
	public ParticleSystem deathSystem;
	public AudioSource soundToPlayWhenDies;
	// Start is called before the first frame update
	void Start()
    {
		// healthTextSign = GameObject.Find("HealthText").GetComponent<TMPro.TMP_Text>();
		
	}

    // Update is called once per frame
    void Update()
    {
		if (healthTextSign != null) {
			healthTextSign.text = "Health: " + Mathf.Round(this.health).ToString();
		}
		if (healthSlider != null) {
			healthSlider.value = Mathf.Round(this.health);
		}
		if (health < 0.5f)
		{
			GameController cont = GameObject.FindObjectOfType<GameController>().gameObject.GetComponent<GameController>();
			cont.kills += 1;
			if (deathSystem != null) {
				ParticleSystem ds = Instantiate(deathSystem);
				
				if (ds.gameObject.name == "ExplodeBETTER(Clone)") {
					ds.gameObject.transform.position = new Vector3(20,4,-22);
					Debug.Log("Is better explosion");
				}
				else {
					ds.gameObject.transform.position = this.gameObject.transform.position;
				}
			}
			if (soundToPlayWhenDies != null) {
				AudioSource ds = Instantiate(soundToPlayWhenDies);
				ds.gameObject.transform.position = this.gameObject.transform.position;
			}
			if (objToDestroy != null) {
				Destroy(objToDestroy);
			}
			
		}
	}

	public void TakeDamage(float damage) {
		health = health - damage;
	}
}
