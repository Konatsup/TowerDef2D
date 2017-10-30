using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

	public float HP;
	public Image gauge_bar;
	public float money;
	public Text costText;
	public float MaxHP;

	// Use this for initialization
	void Start () {
		HP = MaxHP;

	}
		
	public void ReduceHP(int h){
		this.HP -= h;

		this.gauge_bar.fillAmount = this.HP/this.MaxHP;
		if (this.HP <= 0) {
			if(this.gameObject.tag=="Player1"){
				GameManager.instance.ChangeGameState ("end",1);
			}else if(this.gameObject.tag=="Player2"){
				GameManager.instance.ChangeGameState ("end",2);
			}
		}
	}

	public void ReduceMoney(int m){
		this.money -= m;
	}

	public void IncreaseMoney(int m){
		this.money += m;
	}
}
