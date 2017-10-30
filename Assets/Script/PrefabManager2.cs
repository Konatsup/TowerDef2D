using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager2 : MonoBehaviour {

	public Monster2 slimePf;
	public Monster2 attackerPf;
	public Monster2 defenderPf;
	public Monster2 runnerPf;
	public Monster2 collectorPf;

	void Start () {
		attackerPf.AP = 10;
		attackerPf.cost = 200;
		defenderPf.HP = 10;
		defenderPf.cost = 200;
		runnerPf.speed = 4;
		runnerPf.cost = 300;
	}

	public void UpAttackerAP(){
		attackerPf.AP = attackerPf.AP + 3;
		attackerPf.cost = attackerPf.cost + 50;
	}

	public void UpDefenderHP(){
		defenderPf.HP = defenderPf.HP + 5;
		defenderPf.cost = defenderPf.cost + 50;
	}

	public void UpRunnerSpeed(){
		runnerPf.speed = runnerPf.speed + 1;
		runnerPf.cost = runnerPf.cost + 50;
	}
}
