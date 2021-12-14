using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueBoi : MonoBehaviour
{


    public int queBoiIndex = 0;
    Sprite[] queBoi = new Sprite[22];
    string[] desc = new string[22];
    public Text queDesc;
    //public ParticleSystem particle;
    GameObject particles;
    GameObject ongQue;
    public bool AR = false;
    [SerializeField] GameObject title;
    [SerializeField] GameObject shadow;

    private void Awake()
    {
        getQueBoiImage();
        getString();
        particles = GameObject.FindGameObjectWithTag("particles");
        ongQue = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {       
        queBoiIndex = Random.Range(0, 21);
        gameObject.GetComponent<Image>().sprite = queBoi[queBoiIndex];
        gameObject.GetComponent<Image>().SetNativeSize();
        if(queBoiIndex <= 11)
        {
            gameObject.transform.localScale = Vector3.one * 2;
        }
        else
        {
            gameObject.transform.localScale = Vector3.one;
            title.SetActive(false);
            shadow.SetActive(false);
        }
        //gameObject.transform.localScale = Vector3.one * (queBoiIndex <= 11 ? 2 : 1);
        queDesc.text = GameData.queBoiDesc[queBoiIndex];
        saveQue();   
    }

    private void OnDisable()
    {
        particles.SetActive(false);
        ongQue.SetActive(true);
        title.SetActive(true);
        shadow.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getQueBoiImage()
    {
        queBoi[0] = Resources.Load<Sprite>("1");
        queBoi[1] = Resources.Load<Sprite>("2");
        queBoi[2] = Resources.Load<Sprite>("3");
        queBoi[3] = Resources.Load<Sprite>("4");
        queBoi[4] = Resources.Load<Sprite>("5");
        queBoi[5] = Resources.Load<Sprite>("6");
        queBoi[6] = Resources.Load<Sprite>("7");
        queBoi[7] = Resources.Load<Sprite>("8");
        queBoi[8] = Resources.Load<Sprite>("9");
        queBoi[9] = Resources.Load<Sprite>("10");
        queBoi[10] = Resources.Load<Sprite>("11");
        queBoi[11] = Resources.Load<Sprite>("12");
        queBoi[12] = Resources.Load<Sprite>("binh_an");
        queBoi[13] = Resources.Load<Sprite>("hanh_phuc");
        queBoi[14] = Resources.Load<Sprite>("hoan_hi");
        queBoi[15] = Resources.Load<Sprite>("may_man");
        queBoi[16] = Resources.Load<Sprite>("nham_dan");
        queBoi[17] = Resources.Load<Sprite>("suc_khoe");
        queBoi[18] = Resources.Load<Sprite>("sum_vay");
        queBoi[19] = Resources.Load<Sprite>("tai_loc");
        queBoi[20] = Resources.Load<Sprite>("vui_ve");
        queBoi[21] = Resources.Load<Sprite>("vuong_phat");
    }

    void getString()
    {
        

    }

    void saveQue()
    {
        historyItem newItem = new historyItem();
        newItem.ID = queBoiIndex+1;
        newItem.time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm:ss");
        newItem.date = System.DateTime.UtcNow.ToLocalTime().ToString("dd/MM/yyyy");
        PlayerData.historyItemList.Add(newItem);
        if(queBoiIndex<=11)
        {
            PlayerData.zodiacBeast[queBoiIndex]++;
        }
    }    

}
