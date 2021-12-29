﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizom : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawSphere(this.transform.position, 0.5f);
	}
}
