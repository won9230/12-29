using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill1 : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(true);
        Destroy(this.gameObject, 4f);
    }
}
