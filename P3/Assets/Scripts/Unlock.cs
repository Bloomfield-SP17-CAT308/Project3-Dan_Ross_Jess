using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour {

	public GameController gameCon;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other)
	{
		if (gameCon.HasKeyPlatform () && gameCon.HasKeyExplore ())
			Destroy (this.gameObject);
	}
}
