using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager2 : MonoBehaviour {
	[SerializeField]
	private Player player2;
	public PrefabManager2 pfManager2;
	public SoundManager soundManager;

	void Start(){
		player2 = GameObject.FindGameObjectWithTag ("Player2").GetComponent<Player>();
	}

	public void GetAttackItem(){
		pfManager2.UpAttackerAP ();
	}

	public void GetDefenceItem(){
		pfManager2.UpDefenderHP ();
	}

	public void GetSpeedItem(){
		pfManager2.UpRunnerSpeed ();
	}

	public void GetCoin(int point){
		soundManager.CoinSe ();
		player2.IncreaseMoney (point);
	}
}
