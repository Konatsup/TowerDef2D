using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager1 : MonoBehaviour {
	[SerializeField]
	private Player player1;
	public PrefabManager1 pfManager1;
	public SoundManager soundManager;

	void Start(){
		player1 = GameObject.FindGameObjectWithTag ("Player1").GetComponent<Player>();
	}

	public void GetAttackItem(){
		pfManager1.UpAttackerAP ();
	}

	public void GetDefenceItem(){
		pfManager1.UpDefenderHP ();
	}

	public void GetSpeedItem(){
		pfManager1.UpRunnerSpeed ();
	}

	public void GetCoin(int point){
		soundManager.CoinSe ();
		player1.IncreaseMoney (point);
	}

}
