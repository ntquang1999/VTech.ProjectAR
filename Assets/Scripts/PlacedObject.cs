using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{
    public GameObject tiger;
    public Animator ongQue;
    public Animator tigerAnim;
    public ARScene arScene;
    bool shaking = false;

    private void Start()
    {
        arScene = GameObject.FindGameObjectWithTag("AR").GetComponent<ARScene>();
    }

    private void Update()
    {
        if (shaking && tigerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            arScene.showCanvas();
            shaking = false;
        }
        
    }

    public void shake()
    {
        tiger.SetActive(true);
        shaking = true;
        ongQue.SetBool("shake", true);
    }    

}
