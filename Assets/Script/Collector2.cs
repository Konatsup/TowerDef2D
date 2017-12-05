using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector2 : MonoBehaviour {

	public Monster2 monster2; //今の自分自身
	[SerializeField]
	private ItemManager2 itemManager2;

	[SerializeField]
	private bool isItemCatched;
	public bool IsItemCatched { 
		get { return isItemCatched;}
		set { isItemCatched = value;}
	}

	void Start(){
		itemManager2 = GameObject.FindGameObjectWithTag ("ItemManager2").GetComponent<ItemManager2>();
		IsItemCatched = false;

	}

	void Update(){
		if (this.transform.position.x > 9 && monster2.Direction == 1) {
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
				coll.gameObject.GetComponent<Item> ().Direction = monster2.Direction; //Itemの方向をモンスターと同じ方向に
			}
//			if (coll.gameObject.tag == "Item") {
//				if (coll.gameObject.GetComponent<Item> ().Direction != monster2.Direction) {//アイテムを持った仲間とすれ違ったときの例外処理
//					
//				}else{
//					if (coll.gameObject.transform.root.gameObject != null) { //ぶつかったアイテムがすでに他キャラの子要素だったとき、奪い返す
//						Debug.Log("Collector2が奪い返した");
//						Debug.Log(coll.gameObject.transform.root.gameObject.name);
//	//					coll.gameObject.transform.root.gameObject.GetComponent<Collector1>().IsItemCatched = false;
//					}
//					coll.gameObject.transform.parent = this.gameObject.transform; //プレイヤーを親要素に設定
//	//				Debug.Log("dshjkal;2");
//					coll.transform.rotation = Quaternion.Euler (0, 0, 90);
//					IsItemCatched = true;
//					InvertDirection ();
//					coll.gameObject.GetComponent<Item> ().Direction = monster2.Direction; //Itemの方向をモンスターと同じ方向に
//				}
//			}
		}
	}

	//移動方向を反転
	void InvertDirection(){
		monster2.Direction = -1 * monster2.Direction;
	}

	void CarryCompleted(){
		IsItemCatched = false;
		foreach ( Transform child in transform )
		{
			switch(child.GetComponent<Item> ().ID){
			case 1:
				itemManager2.GetAttackItem ();
				break;
			case 2:
				itemManager2.GetDefenceItem ();
				break;
			case 3:
				itemManager2.GetSpeedItem ();
				break;
			case 100:
				itemManager2.GetCoin (100);
				break;
			case 200:
				itemManager2.GetCoin (200);
				break;
			case 300:
				itemManager2.GetCoin (300);
				break;
			case 400:
				itemManager2.GetCoin (400);
				break;
			case 500:
				itemManager2.GetCoin (500);
				break;
			default:
				break;

			}
			Destroy(child.gameObject);
		}
	}

}
