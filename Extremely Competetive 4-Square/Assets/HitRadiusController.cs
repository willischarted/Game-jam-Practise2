using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRadiusController : MonoBehaviour {

	PlayerController playerController;

	// Use this for initialization
	void Start () {
		
		playerController = GetComponentInParent<PlayerController>();
		if (playerController == null)
			Debug.Log("Could not get PlayerController comopnent");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Ball") {
			Debug.Log("Other is Ball");
			playerController.setCanHit(true);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Ball") {
			Debug.Log("Exit was Ball");
			playerController.setCanHit(false);
		}
	}
}
