using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoSuTapController : MonoBehaviour
{

    public List<GameObject> lockImg = new List<GameObject>();
    public List<Text> count = new List<Text>();
    public GameObject menuObject;
    private void Start()
    {
        menuObject = GameObject.FindGameObjectWithTag("menu");
    }

    public void back()
    {
        GameData.menuInput = true;
        menuObject.GetComponent<MainScene>().back();
    }
    public void OnEnable()
    {
        GameData.menuInput = false;
        StartCoroutine(APIController.Collection_Call((completed) => {
            for (int i = 0; i < 12; i++)
            {
                lockImg[i].SetActive(PlayerData.zodiacBeast[i] == 0);
                if(PlayerData.zodiacBeast[i]>0)
                    count[i].text = "x" + PlayerData.zodiacBeast[i].ToString();
            }
        }));

    }

   
    void Update()
    {
        if(menuObject == null)
            menuObject = GameObject.FindGameObjectWithTag("menu");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            back();
            gameObject.SetActive(false);
        }
    }

    public void getPrize()
    {
        
        for (int i =0; i<12;i++)
        {
            if(PlayerData.zodiacBeast[i] == 0)
            {
                GameData.ToastMessage = "Bạn chưa sưu tập đủ, hãy lắc thêm quẻ để sưu tập nhé";
                return;
            }
        }
        StartCoroutine(APIController.GetPrize_Call((completed) => {
            menuObject.GetComponent<MainScene>().showPopup();

        }));
    }    
}
