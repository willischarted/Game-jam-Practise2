using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	public GameObject particle;

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
                if (hit.rigidbody != null)
          			Instantiate(particle, hit.point, Quaternion.identity);
				if (hit.rigidbody.gameObject.name == "Ball")
					Debug.Log("Hit the ball");
			}
        }
	}
}
