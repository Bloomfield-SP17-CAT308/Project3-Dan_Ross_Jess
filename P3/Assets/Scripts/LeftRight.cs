using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour {

	public int start;
	public int length;
	public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 ((Mathf.PingPong (Time.time * speed, length) + start), this.transform.position.y, this.transform.position.z);
	}

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.CompareTag ("Player"))
			other.transform.parent = this.transform;
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.CompareTag ("Player"))
			other.transform.parent = null;
	}
}
