using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
	public Text targetText;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (CheckWeakAttack()) return;
		if (CheckStrongAttack()) return;
	}

	private bool CheckWeakAttack (){
		if ( Input.GetButton ( "WeakAttack" ) )
		{
			Debug.Log("WeakAttack");
			targetText.text = "弱攻撃";
			return true;
		}
		return false;
	}

	private bool CheckStrongAttack (){
		if ( Input.GetButton ( "StrongAttack" ) )
		{
			Debug.Log("StrongAttack");
			targetText.text = "強攻撃";
			return true;
		}
		return false;
	}
}
