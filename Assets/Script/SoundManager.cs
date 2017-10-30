using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	AudioSource audioSource;
	public List<AudioClip> audioClip = new List<AudioClip>();
	public AudioClip audioClip1;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
	}

	public void CoinSe(){
		audioSource.PlayOneShot(audioClip1);
	}
}
