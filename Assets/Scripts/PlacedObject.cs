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
    float timeNormal = 2;
    float timeSpecial = 8;

    //int[] special = {16,19,17,15,14,12,34,25,60,52,53,54};
    int[] special = { 16, 52, 53, 54, 19, 17, 15, 14, 12, 25, 60};
    private void Start()
    {
        arScene = GameObject.FindGameObjectWithTag("AR").GetComponent<ARScene>();
    }

    private void Update()
    {
        if(shaking)
        {
            timeNormal -= Time.deltaTime;
            timeSpecial -= Time.deltaTime;
        }    
        
        if (shaking && isSpecial && timeSpecial <= 0)
        {
            arScene.showCanvas();
            shaking = false;
        }

        if (shaking && !isSpecial && timeNormal <=0)
        {
            arScene.showCanvas();
            shaking = false;
        }

        if (shaking && isSpecial && timeSpecial <= 6.8)
        {
            AudioController.stopSound();
        }


    }

    public void shake()
    {
        foreach(var element in special)
        {
            if (GameData.queBoiIndex == element)
                isSpecial = true;
        }

        if (isSpecial)
        {
            tiger.SetActive(true);
            ongThe.SetActive(false);
        }
        else ongQue.SetBool("shake", true);


        shaking = true;

        AudioController.playShake();
    }

    public void reset()
    {
        tiger.SetActive(false);
        ongThe.SetActive(true);
        ongQue.SetBool("shake", false);
        isSpecial = false;
        timeNormal = 2;
        timeSpecial = 5;
    }

}
