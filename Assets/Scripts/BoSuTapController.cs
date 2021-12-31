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
        menuObject.GetComponent<MainScene>().back();
    }
    public void OnEnable()
    {
        StartCoroutine(APIController.Collection_Call((completed) => {
            for (int i = 0; i < 12; i++)
            {
                lockImg[i].SetActive(PlayerData.zodiacBeast[i] == 0);
                if(PlayerData.zodiacBeast[i]>0)
                    count[i].text = PlayerData.zodiacBeast[i].ToString();
            }
        }));

    }

   
    void Update()
    {
        if(menuObject == null)
            menuObject = GameObject.FindGameObjectWithTag("menu");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
