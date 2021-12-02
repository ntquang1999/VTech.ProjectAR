using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LichSuController : MonoBehaviour
{
    public Transform list;
    public GameObject go;

    private void OnEnable()
    {
        for(int i=0; i < PlayerData.historyItemList.Count; i++)
        {
            GameObject go2 = Instantiate(go, list);
            go2.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("SanPham/2DART/LichSu/Thu/" + PlayerData.historyItemList[i].ID);
            go2.transform.GetChild(0).GetChild(0).GetComponent<Image>().SetNativeSize();
            go2.transform.GetChild(1).GetComponent<Text>().text 
                = "Bạn nhận được phần quà số " + PlayerData.historyItemList[i].ID + " lúc " 
                + PlayerData.historyItemList[i].time + " ngày " + PlayerData.historyItemList[i].date;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
