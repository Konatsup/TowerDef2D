 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public Item Coin200;
	public Item Coin300;
	public Item Coin400;
	public Item Coin500;
	bool dead;

	void Start(){
		this.dead = false;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Item") {
			if (this.transform.position.z > coll.transform.position.z && this.dead == false) {
			switch (coll.gameObject.GetComponent<Item> ().ID) {
				case 100:
					Debug.Log ("Enter2D:100");
					coll.gameObject.GetComponent<Coin> ().dead = true;
					Destroy (coll.gameObject);
					Instantiate (Coin200, new Vector3 (this.transform.position.x, this.transform.position.y, 0), Quaternion.Euler (0, 0, -90));
					Destroy (this.gameObject);
					break;
				case 200:
					Debug.Log ("Enter2D:200");
					Destroy (coll.gameObject);
					Instantiate (Coin300, new Vector3 (this.transform.position.x, this.transform.position.y, 0), Quaternion.Euler (0, 0, -90));
					Destroy (this.gameObject);
					break;
				case 300:
//					Destroy (coll.gameObject);
//					Instantiate (Coin400, new Vector3 (this.transform.position.x, this.transform.position.y, 0), Quaternion.Euler (0, 0, -90));
//					Destroy (this.gameObject);
					break;
				case 400:
//					Destroy (coll.gameObject);
//					Instantiate (Coin500, new Vector3 (this.transform.position.x, this.transform.position.y, 0), Quaternion.Euler (0, 0, -90));
//					Destroy (this.gameObject);
					break;
				default:
					break;
				}
			}
		}
	}
}
