using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


	public float limitTime; //制限時間
	public float passedTime; //経過時間
	public float moneySet;
	public Text timerText1;
	public Text timerText2;
	public Player player1;
	public Player player2;

	// Update is called once per frame
	void Update () {
		passedTime += Time.deltaTime;
		timerText1.text = (limitTime - passedTime).ToString("N2");
		timerText2.text = (limitTime - passedTime).ToString("N2");

		IncreasePlayerMoney (); //お金を増やす

		
	}

	void IncreasePlayerMoney(){
		player1.money += moneySet * Time.deltaTime;
		player1.costText.text = "$ " + player1.money.ToString ("N0");
		player2.money += moneySet * Time.deltaTime;
		player2.costText.text = "$ " + player2.money.ToString ("N0");
	}

	float GetLimitTime(){
		return limitTime;
	}
}
