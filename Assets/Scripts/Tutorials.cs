using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorials : MonoBehaviour
{
    int step = 0;
    [SerializeField] GameObject menuCanvas;
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
                xinQue.transform.parent = gameObject.transform;
                xinQue.GetComponent<Button>().enabled = false;
                desc.text = GameData.tutorialDesc[0];
                break;
            case 5:
                BST.transform.parent = gameObject.transform;
                BST.GetComponent<Button>().enabled = false;
                desc.fontSize = 38;
                desc.text = GameData.tutorialDesc[1];
                break;
            case 4:
                LichSu.transform.parent = gameObject.transform;
                LichSu.GetComponent<Button>().enabled = false;
                desc.text = GameData.tutorialDesc[2];
                break;            
            case 3:
                MoiBan.transform.parent = gameObject.transform;
                MoiBan.GetComponent<Button>().enabled = false;
                desc.text = GameData.tutorialDesc[3];
                break;
            case 2:
                TheLe.transform.parent = gameObject.transform;
                TheLe.GetComponent<Button>().enabled = false;
                desc.text = GameData.tutorialDesc[4];
                break;
            case 1:
                AR.transform.parent = gameObject.transform;
                AR.GetComponent<Button>().enabled = false;
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
        //menuCanvas;
        xinQue.transform.parent = menuCanvas.transform;
        BST.transform.parent = menuCanvas.transform;
        LichSu.transform.parent = menuCanvas.transform;
        MoiBan.transform.parent = menuCanvas.transform;
        TheLe.transform.parent = menuCanvas.transform;        
        AR.transform.parent = menuCanvas.transform;
        xinQue.GetComponent<Button>().enabled = true;
        BST.GetComponent<Button>().enabled = true;
        LichSu.GetComponent<Button>().enabled = true;
        TheLe.GetComponent<Button>().enabled = true;
        AR.GetComponent<Button>().enabled = true;
        MoiBan.GetComponent<Button>().enabled = true;

        desc.fontSize = 40;
        step--;
    }

}
