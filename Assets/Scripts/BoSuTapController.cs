using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoSuTapController : MonoBehaviour
{

    public List<GameObject> lockImg = new List<GameObject>();
    public List<Text> count = new List<Text>();
    public GameObject menuObject;
    int min = 1000000;
    [SerializeField] Text collectionPrizeTime;
    [SerializeField] Button getPrizeBtn;
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
                if (PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime <= min)
                {
                    min = PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime;
                }
                lockImg[i].SetActive(PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime == 0);
                if(PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime > 0)
                    count[i].text = "x" + (PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime);
                else 
                {
                    count[i].text = "Khoá";
                } 
                    
            }
        }));  
    }

   
    void Update()
    {
        if (min == 0)
        {
            getPrizeBtn.gameObject.SetActive(false);
        }
        else
        collectionPrizeTime.text = GameData.collectionPrizeTime+"";
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
            StartCoroutine(APIController.Collection_Call((completed) => {
                for (int i = 0; i < 12; i++)
                {
                    if (PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime <= min)
                    {
                        min = PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime;
                    }
                    lockImg[i].SetActive(PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime == 0);
                    if (PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime > 0)
                        count[i].text = "x" + (PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime);
                    else
                    {
                        count[i].text = "Khoá";
                    }

                }
            }));
        }));
    }    
}
