using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XacNhanController : MonoBehaviour
{

    public Text sdtbox;
    public GameObject thisCanvas;
    public GameObject confirmPopup;
    public GameObject confirmBtn;
    MainScene mainScene;


    // Start is called before the first frame update
    void Start()
    {
        mainScene = GameObject.FindGameObjectWithTag("menu").GetComponent<MainScene>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void lanToa()
    {
        string sdt = "00000";
        if (sdtbox.text.Length > 0)
        {
            sdt = "84" + sdtbox.text.Substring(1);
        }

        //Debug.LogError("Lan toa thanh congzzzzzzzz");
        StartCoroutine(APIController.Confirm_Call(sdt, (completed) => {
            //Debug.LogError("Lan toa thanh cong"); 
            //mainScene.showToastMessage();
            confirmPopup.SetActive(true);
            confirmBtn.SetActive(false);
            thisCanvas.SetActive(false);
            
        }));
    }

}

