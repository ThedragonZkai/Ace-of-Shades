using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
	public float health;
	public GameObject objToDestroy;
	public TMP_Text healthTextSign;
	public ParticleSystem deathSystem;
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
		if (health < 0.5f)
		{
			GameController cont = GameObject.FindObjectOfType<GameController>().gameObject.GetComponent<GameController>();
			cont.kills += 1;
			if (deathSystem != null) {
				ParticleSystem ds = Instantiate(deathSystem);
				ds.gameObject.transform.position = this.gameObject.transform.position;
			}
			Destroy(objToDestroy);
		}
	}

	public void TakeDamage(float damage) {
		health = health - damage;
	}
}
