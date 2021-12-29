using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
	private void OnTriggerEnter(Collider other)
	{
        transform.DOShakePosition(1f);
	}
}
