using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
	bool t = true;
	float x;

	float time = 0.5f;
	// Use this for initialization
	void Start()
	{
		x = transform.position.x;
	}
	void Update()
	{
		if (transform.position.x >= x + 1)
		{
			t = false;
		}
		if (transform.position.x <= x - 1)
		{
			t = true;
		}
		if (t == true)
		{
			transform.Translate(0, Time.deltaTime, 0);
		}
		if (t == false)
		{
			transform.Translate(0, -Time.deltaTime, 0);
		}
		time -= Time.deltaTime;
		
	}
}
