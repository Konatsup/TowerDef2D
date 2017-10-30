using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour {

	private float nextPosX;
	private float startPosY;
	public int HP;
	public int AP;
	public float speed;
	public int cost;
	public Item Coin;
	bool dead;
	private int direction;
	public int Direction { 
		get { return direction;}
		set { direction = value;}
	}

	void Start () {
		dead = false;
		nextPosX = this.transform.position.x;
		startPosY = this.transform.position.y;
		direction = 1;
	}

	void Update () {
		if (nextPosX > 9) {
			Destroy (this.gameObject);
		}
		nextPosX += speed * direction * 0.015f;
		gameObject.transform.position = new Vector3(nextPosX,startPosY,0f);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Monster2") {
			this.HP = this.HP - coll.gameObject.GetComponent<Monster2>().AP;
			if (HP < 0 && dead == false) {
				dead = true;
				Debug.Log ("MonsterEnter1"+this.HP);
				transform.DetachChildren();
				Instantiate (Coin, new Vector3 (nextPosX, startPosY, Random.Range(1.0f,100.0f)), Quaternion.Euler (0, 0, -90));
				Destroy (this.gameObject);
			}
			nextPosX -= 2;
		}

		if (coll.gameObject.tag == "Player2") {
			coll.gameObject.GetComponent<Player>().ReduceHP(this.AP);
			nextPosX -= 2;
		}
	}

}
