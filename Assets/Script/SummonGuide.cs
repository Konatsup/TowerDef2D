using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SummonGuide : MonoBehaviour {

	private Image imageColor;

	void Start () {
		imageColor = this.gameObject.GetComponent<Image> ();
		
	}

	public void NormalizeColor(){
		this.imageColor.color = new Color (1.0f,0.0f,0.0f,0.5f);
	}

	public void DeepenColor(){
		this.imageColor.color = new Color (1.0f,0.0f,0.0f,0.9f);
	}
}
