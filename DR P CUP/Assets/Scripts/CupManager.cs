using UnityEngine;
using System.Collections;

public class CupManager : MonoBehaviour {

	public GameObject PeeStick;
	public Bars BarsCode;
	private Vector3 startPos;
	private float endPos = 0;
	bool moving = false;

	Vector3 goal;

	// Use this for initialization
	void Start () {
		startPos = PeeStick.transform.position;
	}

// Update is called once per frame
	void Update () {
		if(moving){
			Movement();
		}
	}

	void OnMouseDown(){
		moving = true;

		goal = PeeStick.transform.position;
		goal.y = endPos;
	}

	public void Movement(){
		/*Vector3 endPosition = PeeStick.transform.position;
		endPosition.y = endPos;*/

		if(PeeStick.transform.position == goal){
			if(goal == startPos){
				moving = false;
				BarsCode.newDisease();
			}
			else{
				goal = startPos;
			}
		}
		
		PeeStick.transform.position = Vector3.Lerp(PeeStick.transform.position, goal, .15f);	
	}
	
	

	
}
