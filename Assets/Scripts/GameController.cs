using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
	public AudioSource mainMusic;
	public AudioSource bossmusic;
	public AudioSource winMusic;
	public GameObject leftController;
	public GameObject rightController;
	public float testingSpeed = 0.1f;
	public float testingRotateSpeed = 0.1f;
	bool testingMode = false;
	public int stage;
	public int heightToSetDoorsTo;
	public float lerpSpeed;
	public int kills;
	public GameObject EndScreen;

	public Vector3 worldPosition;
	Plane plane = new Plane(Vector3.up, 0);
	public GameObject[] doors;
	private float timeChangeEndScreen = 0;

	// Start is called before the first frame update
	void Start()
    {
		EndScreen.SetActive(false);
		stage = 0;
		mainMusic.Play();
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.T)) {
			testingMode = true;
			Debug.Log("Testing Mode initiated");
		}

		if (testingMode) {
			float testSpeedMod = testingSpeed;
			if (Input.GetKey(KeyCode.W)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(0, 0, testingSpeed));
			}
			if (Input.GetKey(KeyCode.A)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(-testingSpeed, 0, 0));
			}
			if (Input.GetKey(KeyCode.S)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(0, 0, -testingSpeed));
			}
			if (Input.GetKey(KeyCode.D)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(testingSpeed, 0, 0));
			}
			if (Input.GetKey(KeyCode.E)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(0, testingSpeed, 0));
			}
			if (Input.GetKey(KeyCode.Q)) {
				leftController.transform.position = leftController.transform.position + (new Vector3(0, -testingSpeed, 0));
			}

			float distance;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (plane.Raycast(ray, out distance))
			{
				worldPosition = ray.GetPoint(distance);
			}
			leftController.transform.LookAt(worldPosition);
		
			//make the ray come from the controller or soemthing idk


			// if (Input.GetKey(KeyCode.UpArrow)) {
			// 	leftController.transform.eulerAngles += new Vector3(-testingRotateSpeed,0,0);
			// }
			// if (Input.GetKey(KeyCode.LeftArrow)) {
			// 	leftController.transform.eulerAngles += new Vector3(0,testingRotateSpeed,0);
			// }
			// if (Input.GetKey(KeyCode.DownArrow)) {
			// 	leftController.transform.eulerAngles += new Vector3(testingRotateSpeed,0,0);
			// }
			// if (Input.GetKey(KeyCode.RightArrow)) {
			// 	leftController.transform.eulerAngles += new Vector3(0,-testingRotateSpeed,0);
			// }
		}
		int tmp = 0;
		foreach (GameObject door in doors)
		{
			if (stage == 5) {
				lerpSpeed = 0.1f;
			}
			if (stage > tmp)
			{
				door.transform.position = new Vector3(door.transform.position.x, Mathf.Lerp(door.transform.position.y,heightToSetDoorsTo, Time.deltaTime * lerpSpeed),door.transform.position.z);
			}
			tmp += 1;
		}

		if (kills >= 2 && stage == 0) {
			stage = 1;
			kills = 0;
		}
		if (kills >= 5 && stage == 2) {
			stage = 3;
			kills = 0;
		}
		if (kills >= 5 && stage == 3) {
			initiateBoss();
			stage = 5;
			kills = 0;
		}
		if (kills >=10 && stage == 5) { //change this later 
			win();
			timeChangeEndScreen =  timeChangeEndScreen + Time.deltaTime;
			EndScreen.SetActive(true);
			EndScreen.GetComponent<Image>().color = new Color(255,255,255,( timeChangeEndScreen * 100)/255);
			EndScreen.GetComponentInChildren<TMP_Text>().color = new Color(0,0,0,(( timeChangeEndScreen * 100) - 610) / 255);

		}

	}

	public void ShadesPickup() {
		stage = 2;
	}

	private void initiateBoss() {
		if (mainMusic.isPlaying) {
			mainMusic.Stop();
			bossmusic.Play();
		}
	}
	private void win() {
		if (!winMusic.isPlaying) {
			bossmusic.Stop();
			winMusic.Play();
		}
	}
}
