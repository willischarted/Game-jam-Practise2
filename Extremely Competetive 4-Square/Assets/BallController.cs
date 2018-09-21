using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	Rigidbody rb;

	private bool isHit;
	private Vector3 movement;

	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		if (rb == null){
			Debug.Log("Could not get ball");
		}

		isHit = false;
		movement = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		hitBall();
	}

	public void hitBall() {
		if (isHit) {

			rb.AddForce(movement * speed);
			isHit = false;
			movement.Set(0f,0f,0f);
		}
	}

	public void setIsHit(bool _isHit){
		isHit = _isHit;
	}

	public void setMovement(Vector3 _movement) {
		movement = _movement;
	}
}
