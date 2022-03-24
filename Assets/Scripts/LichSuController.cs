using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LichSuController : MonoBehaviour
{
    public Transform list;
    public GameObject go;
    public ScrollRect scroll;
    const int MAX_HISTORY_ITEM = 25;
    public GameObject menuObject;

    private void Awake()
    {
        menuObject = GameObject.FindGameObjectWithTag("menu");
    }

    public void back()
    {
        GameData.menuInput = true;
        menuObject.GetComponent<MainScene>().back();
    }
    private void OnEnable()
    {
        GameData.menuInput = false;
        StartCoroutine(APIController.History_Call((completed)=> {
            scroll.content.anchoredPosition = new Vector2(scroll.content.anchoredPosition.x, 0);
            for (int i = PlayerData.historyItemList.Count - 1; i >= 0; i--)
            {
                GameObject go2 = Instantiate(go, list);
                go2.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = GameData.queBoiHistory[PlayerData.historyItemList[i].ID];
                //go2.transform.GetChild(0).GetChild(0).GetComponent<Image>().SetNativeSize();
                //if (PlayerData.historyItemList[i].ID >= 23 && PlayerData.historyItemList[i].ID <= 52)
                   // go2.transform.GetChild(0).GetChild(0).localScale = Vector3.one * 0.3f;
          
                go2.transform.GetChild(1).GetComponent<Text>().text
                    = "Bạn nhận được " + (PlayerData.historyItemList[i].name) + " lúc "
                    + PlayerData.historyItemList[i].time + " ngày " + PlayerData.historyItemList[i].date;
            }
        }));
        
    }
    private void OnDisable()
    {
        //List<Transform> listChild = new List<Transform>();
        foreach(Transform child in list)
        {
            Destroy(child.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        menuObject = GameObject.FindGameObjectWithTag("menu");
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            back();
            gameObject.SetActive(false);
        }
    }
}
