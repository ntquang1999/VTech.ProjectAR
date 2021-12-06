using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BangXepHangController : MonoBehaviour
{
    public List<Text> phoneNumber = new List<Text>();
    public List<Text> zodiacBeastCount = new List<Text>();
    public GameObject menuObject;

    private void OnEnable()
   {
        for(int i=0; i<10;i++)
        {
            phoneNumber[i].text = GameData.rankList[i].number;
            zodiacBeastCount[i].text = GameData.rankList[i].zodiacBeastCount.ToString();
        }
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            menuObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
