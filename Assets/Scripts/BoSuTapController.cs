using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoSuTapController : MonoBehaviour
{

    public List<GameObject> lockImg = new List<GameObject>();
    public List<Text> count = new List<Text>();
    public List<Text> txtNames = new List<Text>();
    public GameObject menuObject;
    int min = 1000000;
    string[] zodiacName = new string[] { "Tí", "Sửu", "Dần", "Mão", "Thìn", "Tỵ", "Ngọ", "Mùi", "Thân", "Dậu", "Tuất", "Hợi" };
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
        //getPrizeBtn.gameObject.SetActive(false);
        GetPrizeInfo();
    }


    void Update()
    {
        //if (min == 0)
        //{
        //    getPrizeBtn.gameObject.SetActive(false);
        //}
        //else getPrizeBtn.gameObject.SetActive(true);
        collectionPrizeTime.text = GameData.collectionPrizeTime + "";
        if (menuObject == null)
            menuObject = GameObject.FindGameObjectWithTag("menu");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            back();
            gameObject.SetActive(false);
        }
    }

    public void getPrize()
    {

        /*for (int i = 0; i < 12; i++)
        {
            if (PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime <= 0)
            {
                GameData.ToastMessage = "Bạn chưa sưu tập đủ, hãy lắc thêm quẻ để sưu tập nhé";
                return;
            }
        }*/
        StartCoroutine(APIController.GetPrize_Call((completed) =>
        {
            menuObject.GetComponent<MainScene>().showPopup();
            GetPrizeInfo();
        }));
    }

    private void GetPrizeInfo()
    {
        min = 100000;
        StartCoroutine(APIController.Collection_Call((completed, json) =>
        {
            if (json["errorCode"].AsInt != 0) return;
            string[] codes = new string[] { "CHUOT", "TRAU", "HO", "MEO", "RONG", "RAN", "NGUA", "DE",
                                        "KHI", "GA", "CHO", "LON"};
            for (int i = 0; i < 12; i++)
            {
                string code = codes[i];
                int _count = PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime;
                if (PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime <= min)
                {
                    min = PlayerData.zodiacBeast[i] - GameData.collectionPrizeTime;
                }
                lockImg[i].SetActive(_count == 0);
                count[i].text = $"x{_count}";
                count[i].gameObject.SetActive(_count > 0);
                count[i].transform.parent.gameObject.SetActive(_count > 0);
                txtNames[i].text = GameData.GetTenLinhThu(code);
            }

            //int countLinhThu = 0;
            //foreach (JSONNode node in json["data"])
            //{
                //if (node["total"].AsInt > 0)
                    //countLinhThu++;
            //}
            //getPrizeBtn.gameObject.SetActive(countLinhThu >= 12);
        }));
    }
}
