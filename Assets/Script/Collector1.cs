using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector1 : MonoBehaviour {

	public Monster1 monster1;
	[SerializeField]
	private ItemManager1 itemManager1;

	[SerializeField]
	private bool isItemCatched;
	public bool IsItemCatched { 
		get { return isItemCatched;}
		set { isItemCatched = value;}
	}

	void Start(){
		itemManager1 = GameObject.FindGameObjectWithTag ("ItemManager1").GetComponent<ItemManager1> ();
		IsItemCatched = false;

	}

	void Update(){
		if (this.transform.position.x < -9 && monster1.Direction == -1) {
			InvertDirection ();
			CarryCompleted ();
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (IsItemCatched == false) { //アイテムを持っていないとき
			if (coll.gameObject.tag == "Item") {
				if (coll.gameObject.transform.root.gameObject != null) { //ぶつかったアイテムがすでに他キャラの子要素だったとき、奪い返す
					Debug.Log("Collector1が奪い返した");
					Debug.Log(coll.gameObject.transform.root.gameObject.name);
//					coll.gameObject.transform.root.gameObject.GetComponent<Collector2>().IsItemCatched = false;
				}

				coll.gameObject.transform.parent = this.gameObject.transform; //プレイヤーを親要素に設定
//				Debug.Log("dshjkal;");
				coll.transform.rotation = Quaternion.Euler(0, 0, -90);
				IsItemCatched = true;
				InvertDirection ();
				coll.gameObject.GetComponent<Item> ().Direction = monster1.Direction; //Itemの方向をモンスターと同じ方向に
			}
		}
	}
		
	//移動方向を反転
	void InvertDirection(){
		monster1.Direction = -1 * monster1.Direction;
	}

	void CarryCompleted(){
		IsItemCatched = false;
		foreach ( Transform child in transform )
		{
			switch(child.GetComponent<Item> ().ID){
			case 1:
				itemManager1.GetAttackItem ();
				break;
			case 2:
				itemManager1.GetDefenceItem ();
				break;
			case 3:
				itemManager1.GetSpeedItem ();
				break;
			case 100:
				itemManager1.GetCoin (100);
				break;
			case 200:
				itemManager1.GetCoin (200);
				break;
			case 300:
				itemManager1.GetCoin (300);
				break;
			case 400:
				itemManager1.GetCoin (400);
				break;
			case 500:
				itemManager1.GetCoin (500);
				break;
			default:
				break;

			}
			Destroy(child.gameObject);
		}
	}

}