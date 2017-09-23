using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour {

	public float speed = 0.1f;

	private float nextPosX;
	// Use this for initialization

	void Start () {
		nextPosX = this.transform.position.x;
		
	}
	
	// Update is called once per frame
	void Update () {
		nextPosX += speed * 1.0f;
		gameObject.transform.position = new Vector3(nextPosX,0f,0f);

	}

	void OnCollisionEnter2D(Collision2D coll){


		if (coll.gameObject.tag == "Monster1") {
			Debug.Log ("monste1と小っと雨");

		}

	}
}
