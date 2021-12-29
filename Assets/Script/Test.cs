﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
		}		
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
		}
	}
}
