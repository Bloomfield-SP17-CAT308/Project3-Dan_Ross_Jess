using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupExp : MonoBehaviour {

	public GameController gamecon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		gamecon.GetKeyExp ();
		Destroy (this);
	}
}
