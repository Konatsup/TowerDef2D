using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;

	// Use this for initialization
	void Start ()
	{
		instance = this;
//		StartCoroutine(DelayMethod(3.5f, () =>
//			{
//				Debug.Log("Delay call");
//			}));
		
	}

	public void ChangeGameState (string state, int playerId)
	{

		Debug.Log ("EndGameCalled!!");
		switch (state) {
		case "start":
			Time.timeScale = 0;
			break;

		case "end":
			if (playerId == 1) {
				Debug.Log ("Player 2 Win!!");
			} else if (playerId == 2) {
				Debug.Log ("Player 1 Win!!");
			}
			break;
		default:
			break;
		}

	}


	private IEnumerator DelayMethod(float waitTime, Action action)
	{
		yield return new WaitForSeconds(waitTime);
		//action();
	}

}
