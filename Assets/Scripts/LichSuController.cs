﻿using System.Collections;
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

    private void OnEnable()
    {
        scroll.content.anchoredPosition = new Vector2(scroll.content.anchoredPosition.x, 0);
        for (int i= PlayerData.historyItemList.Count-1; i >= 0 ; i--)
        {
            GameObject go2 = Instantiate(go, list);
            go2.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("History/" + PlayerData.historyItemList[i].ID);
            go2.transform.GetChild(0).GetChild(0).GetComponent<Image>().SetNativeSize();
            //int temp = 
            go2.transform.GetChild(1).GetComponent<Text>().text 
                = "Bạn nhận được phần quà số " + (PlayerData.historyItemList[i].ID+1) + " lúc " 
                + PlayerData.historyItemList[i].time + " ngày " + PlayerData.historyItemList[i].date;
        }
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
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            menuObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}