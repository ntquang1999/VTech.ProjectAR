using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorials : MonoBehaviour
{
    int step = 0;
    [SerializeField] GameObject xinQue;
    [SerializeField] GameObject BST;
    [SerializeField] GameObject LichSu;
    [SerializeField] GameObject MoiBan;
    [SerializeField] GameObject TheLe;
    [SerializeField] GameObject BXH;
    [SerializeField] GameObject Share;
    [SerializeField] GameObject AR;
    [SerializeField] Text desc;

    void Start()
    {
        if(PlayerData.firstTime)
        {
            step = 6;
            PlayerData.firstTime = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(step)
        {
            case 6:
                xinQue.SetActive(true);
                desc.text = GameData.tutorialDesc[0];
                break;
            case 5:
                BST.SetActive(true);
                desc.fontSize = 38;
                desc.text = GameData.tutorialDesc[1];
                break;
            case 4:
                LichSu.SetActive(true);
                desc.text = GameData.tutorialDesc[2];
                break;            
            case 3:
                MoiBan.SetActive(true);
                desc.text = GameData.tutorialDesc[3];
                break;
            case 2:
                TheLe.SetActive(true);
                desc.text = GameData.tutorialDesc[4];
                break;
            case 1:
                AR.SetActive(true);
                desc.fontSize = 38;
                desc.text = GameData.tutorialDesc[5];
                break;
            case 0:
                gameObject.SetActive(false);
                break;
        }
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                completeStep();
            }
        }
    }

    public void completeStep()
    {
        xinQue.SetActive(false);
        BST.SetActive(false);
        LichSu.SetActive(false);
        MoiBan.SetActive(false);
        TheLe.SetActive(false);
        AR.SetActive(false);

        desc.fontSize = 40;
        step--;
    }

}
