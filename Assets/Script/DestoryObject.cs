using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{
    public float destroySecrt;
    void Start()
    {
        Destroy(this.gameObject, destroySecrt);
    }
}
