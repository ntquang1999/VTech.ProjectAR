using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{
    public GameObject tiger;
    public GameObject ongThe;
    public Animator ongQue;
    public Animator tigerAnim;
    public ARScene arScene;
    bool shaking = false;
    bool isSpecial = false;

    int[] special = {16,19,17,15,14,12,34,25,60};

    private void Start()
    {
        arScene = GameObject.FindGameObjectWithTag("AR").GetComponent<ARScene>();
    }

    private void Update()
    {
        if (shaking && isSpecial &&tigerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            arScene.showCanvas();
            shaking = false;
        }

        if (shaking && ongQue.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            arScene.showCanvas();
            shaking = false;
        }
    }

    public void shake()
    {
        for(int i = 0; i<10;i++)
        {
            if (GameData.queBoiIndex == special[i])
                isSpecial = true;
        }
        
        shaking = true;
        
        if (isSpecial)
        {
            tiger.SetActive(true);           
            ongThe.SetActive(false);
        }
        else ongQue.SetBool("shake", true);
    }

    public void reset()
    {
        tiger.SetActive(false);
        ongThe.SetActive(true);
        ongQue.SetBool("shake", false);
    }

}
