using UnityEngine;
using System.Collections;



public class SwingShot : MonoBehaviour {

	 public int speed = 10;
	//var target : Transform;
	public GameObject target;



	void Update () {

		Vector3 pos = target.transform.position;
		transform.RotateAround (target.transform.position, Vector3.up, speed);
		Debug.Log ("Positoon of rotation : "+target.transform.position+"@@@@"+pos);

		//target.transform.position = target.transform.position - 0.1f;
	}
}
