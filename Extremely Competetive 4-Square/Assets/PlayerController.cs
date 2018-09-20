using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody rb;

	public float speed;

	public GameObject ball;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		if (rb == null)
			Debug.Log("Could not find rigidbody!");
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt(ball.transform);
		
	}

	void FixedUpdate() {
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		Vector3 movement = new Vector3(horizontal, 0f,vertical);
		movement = movement.normalized * speed * Time.deltaTime;


		rb.MovePosition(transform.position + movement);
	}
}
