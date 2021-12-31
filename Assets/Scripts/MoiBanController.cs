using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoiBanController : MonoBehaviour
{

    public Text sdtbox;
    public GameObject thisCanvas;
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
        StartCoroutine(APIController.Share_Call(sdt, (completed) => {
            //Debug.LogError("Lan toa thanh cong"); 
            mainScene.showToastMessage();
            thisCanvas.SetActive(false);

        }));
    }    

}
