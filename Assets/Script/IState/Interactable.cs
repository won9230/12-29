using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public float radius = 1f;
	public Transform interactionTransform;

	public virtual void Interact()
	{
		//Debug.Log("Interacting with" + transform.name);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PLAYER"))
		{
			Interact();
		}
	}
}
