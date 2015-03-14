﻿using UnityEngine;
using System.Collections;

public class SpeedyScript : MonoBehaviour {

	public bool DEBUG_MODE;
	Vector3 destination;
	bool travel = true;
	public float MAX_SPEED = 5000f;	
	
	GameObject leftPart,rightPart;
	
	
	// Use this for initialization
	void Start () {
		DEBUG_MODE = false;
		destination = -transform.position;
		if (DEBUG_MODE)
			Debug.Log (destination);
		leftPart = Resources.Load ("SpeedyL") as GameObject;
		rightPart = Resources.Load ("SpeedyR") as GameObject;
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag.Equals ("Player")  && canKill (coll.rigidbody))
			death ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (travel) {
			if (GeneralPhysics.onSpot (this.transform.position, destination))
				Destroy(this.gameObject);
			else {
				if (GetComponent<Rigidbody2D>().velocity.magnitude<MAX_SPEED)
					GetComponent<Rigidbody2D>().AddForce (destination-transform.position.normalized*1000);
			}
		} else
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
	}
	
	public void death(){
		if (leftPart != null) {
			GameObject left = Instantiate (leftPart, transform.position, Quaternion.identity) as GameObject;
			left.GetComponent<Rigidbody2D>().AddForce (new Vector2 (-10, -10));
			Destroy (left, 1);
		}
		if (rightPart != null) {
			GameObject right = Instantiate (rightPart, transform.position, Quaternion.identity) as GameObject;
			right.GetComponent<Rigidbody2D>().AddForce (new Vector2 (10, -10));
			Destroy (right, 1);
		}
		Destroy (this.gameObject);
	}

	private bool canKill(Rigidbody2D controller) {
		float overallSpeed = controller.velocity.magnitude;
		Debug.Log("Magnitude is: " + overallSpeed);
		return GeneralPhysics.MagnitudeToKill < overallSpeed;
		
	}
}