using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	
	public float ballHitForce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1"))
        {
			RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit)) {
                if (hit.rigidbody != null) {
					if (hit.rigidbody.gameObject.name == "Ball"){
						Debug.Log("Hit the ball");
						hit.rigidbody.AddForceAtPosition(ray.direction * ballHitForce, hit.point);
						//hit.rigidbody.AddExplosionForce(ballHitForce,hit.point,1);
						
					}
				}
			}
        }
	}
}
