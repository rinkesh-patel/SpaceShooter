﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundry
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundry boundry;

	public GameObject shot;
	public Transform shotspawn;
	public float fireRate;

	private float nextFire;
	void Update ()
	{
		if (Input.GetKey("space") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotspawn.position, shotspawn.rotation);
			audio.Play ();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new	Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;


		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundry.xMin, boundry.xMax),
				0.0f,
				Mathf.Clamp (rigidbody.position.z, boundry.zMin, boundry.zMax)
			);

		rigidbody.rotation = Quaternion.Euler 
			(
				0.0f,
				0.0f,
				rigidbody.velocity.x * -tilt
			);
	}
}
