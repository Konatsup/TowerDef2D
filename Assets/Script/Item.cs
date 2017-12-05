using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public int ID;
	[SerializeField]
	private int direction;
	public int Direction { 
		get { return direction;}
		set { direction = value;}
	}

	void Start(){
		Direction=0;
	}
		
}
