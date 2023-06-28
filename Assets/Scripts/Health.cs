using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
	public int health;
	public GameObject objToDestroy;
	public TMP_Text healthTextSign;
	// Start is called before the first frame update
	void Start()
    {
		// healthTextSign = GameObject.Find("HealthText").GetComponent<TMPro.TMP_Text>();
	}

    // Update is called once per frame
    void Update()
    {
		if (healthTextSign != null) {
			healthTextSign.text = "Health: " + this.health.ToString();
		}
		if (health < 0)
		{
			Destroy(objToDestroy);
		}
	}

	public void TakeDamage(int damage) {
		health = health - damage;
	}
}
