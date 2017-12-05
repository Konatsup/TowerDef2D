using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript1 : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler{

	public Monster1 monster1;
	public Player player;
	public Image monsterImage;
	public SummonGuide sg0;
	public SummonGuide sg1;
	public SummonGuide sg2;
	public SummonGuide sg3;
	public SummonGuide sg4;
	public SoundManager soundManager;
	private SummonGuide[] summonGuides;
	private float _SGRadius;
	private int i;
	private int monsterCost;
	private float y;


	void Start(){
		summonGuides = new SummonGuide[]{
			sg0,
			sg1,
			sg2,
			sg3,
			sg4
		};
		_SGRadius = 30f;
		monsterCost = monster1.cost;

	}


	public void OnBeginDrag(PointerEventData eventData){
		foreach (SummonGuide sg in summonGuides) {
			sg.gameObject.SetActive (true);
			monsterImage.gameObject.SetActive (true);
		}

	}

	public void OnDrag(PointerEventData eventData){

		monsterImage.transform.position = new Vector2 (eventData.position.x,eventData.position.y);
		foreach (SummonGuide sg in summonGuides) {
			if ((Mathf.Abs (monsterImage.transform.position.x - sg.transform.position.x) < _SGRadius)
			    && (Mathf.Abs (monsterImage.transform.position.y - sg.transform.position.y) < _SGRadius)) {
				sg.DeepenColor ();
			} else {
				sg.NormalizeColor ();
			}
		}

	}



		
	public void OnEndDrag(PointerEventData eventData){
		monsterImage.gameObject.SetActive (false);
		monsterImage.transform.position = new Vector2 (eventData.position.x,eventData.position.y);
		for (int i = 0; i < summonGuides.Length; i++) {
			summonGuides[i].gameObject.SetActive (false);
			if ((Mathf.Abs (monsterImage.transform.position.x - summonGuides [i].transform.position.x) < _SGRadius)
			    && (Mathf.Abs (monsterImage.transform.position.y - summonGuides [i].transform.position.y) < _SGRadius)) {
				switch (i) {
				case 0:
					y = 4;
					break;
				case 1:
					y = 2;
					break;
				case 2:
					y = 0;
					break;
				case 3:
					y = -2;
					break;
				case 4:
					y = -4;
					break;

				}

				if(player.money >= monsterCost){ 
					soundManager.CoinSe ();
					Instantiate (monster1, new Vector3 (-6, y, 0), Quaternion.Euler (0, 0, -90));
					player.ReduceMoney (monsterCost);
				}
			}
		}
			
	}


}
