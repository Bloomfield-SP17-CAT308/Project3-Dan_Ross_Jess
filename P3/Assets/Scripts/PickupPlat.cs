using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPlat : MonoBehaviour {

	public GameController gameCon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		gameCon.GetKeyPlat ();
		Destroy (this.gameObject);
	}
}
