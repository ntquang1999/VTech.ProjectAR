using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoSuTapController : MonoBehaviour
{

    public List<GameObject> lockImg = new List<GameObject>();
    public GameObject menuObject;
    public void OnEnable()
    {
        for(int i = 0; i<12;i++)
        {
            lockImg[i].SetActive(PlayerData.zodiacBeast[i] == 0);
        }
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
