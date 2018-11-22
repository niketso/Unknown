using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour {

	float destroyTime = 3.0f;
	private Vector3 offset =new Vector3(0,2,0);
	private Quaternion rotOffset = new Quaternion(0f,220f,0f,0f);
	void Start()
	{
		Destroy(gameObject,destroyTime);
		transform.position -= offset;
		transform.rotation = rotOffset;
	}
	
	
	
}

