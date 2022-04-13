using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spark : MonoBehaviour
{
    //int combo = 1;
    void Start()
    {
        transform.GetComponent<Renderer>().material.DOFade(0, 1);
        Destroy(gameObject, 1);
    }

    
    void Update()
    {
        
    }
}
