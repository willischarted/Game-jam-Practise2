using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody rb;

	public float speed;

	public GameObject ball;
	private BallController ballController;

	private bool canHit;

	private bool hitting;

	public float hitTimer;
	private float hitTimerElapsed;

	public float ballHitY;

	


	// Use this for initialization
	void Start () {
		canHit = false;
		hitting = false;
		hitTimerElapsed = 0f;

		rb = GetComponent<Rigidbody>();
		if (rb == null)
			Debug.Log("Could not find rigidbody!");

		ballController = ball.GetComponent<BallController>();
		if (ballController == null) {
			Debug.Log("Could get ballController!");
		}
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt(ball.transform);

		if (Input.GetButtonDown("R2")) {
			hitting = true;
			Debug.Log("Hitting");
		}

		//if (Input.GetButtonUp("R2")) {		
		//}

		if (hitting) {
			hitTimerElapsed += Time.deltaTime;
		}

		if (hitTimerElapsed >= hitTimer) {
			hitting = false;
			hitTimerElapsed = 0f;
		}
		
	}

	void FixedUpdate() {
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		
		
		if (!hitting){
			Vector3 movement = new Vector3(horizontal, 0f,vertical);
			movement = movement.normalized * speed * Time.deltaTime;


			rb.MovePosition(transform.position + movement);
		}

		else if (canHit) {
			Vector3 movement = new Vector3(horizontal, ballHitY,vertical);
			ballController.setMovement(movement);
			ballController.setIsHit(true);
			hitting = false;	
		}
	}

	public void setCanHit(bool _canHit) {
		canHit = _canHit;
	}

	public void setHitting(bool _hitting) {
		hitting = _hitting;
	}
}
