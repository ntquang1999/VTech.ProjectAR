using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueBoi : MonoBehaviour
{


    public int queBoiIndex = 0;
    Sprite[] queBoi = new Sprite[100];
    string[] desc = new string[52];
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
        
        queBoiIndex = GameData.queBoiIndex;
        gameObject.GetComponent<Image>().sprite = queBoi[queBoiIndex];
        gameObject.GetComponent<Image>().SetNativeSize();
        if(queBoiIndex <= 11)
        {
            gameObject.transform.localScale = Vector3.one * 2;
        }
        else
        {
            gameObject.transform.localScale = Vector3.one * 0.8f;
            title.SetActive(false);
            shadow.SetActive(false);
        }
        //gameObject.transform.localScale = Vector3.one * (queBoiIndex <= 11 ? 2 : 1);
        queDesc.text = GameData.queBoiDescReal;
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
        queBoi[22] = Resources.Load<Sprite>("anlanh");
        queBoi[23] = Resources.Load<Sprite>("anyen");
        queBoi[24] = Resources.Load<Sprite>("daian");
        queBoi[25] = Resources.Load<Sprite>("daicat");
        queBoi[26] = Resources.Load<Sprite>("dailoc");
        queBoi[27] = Resources.Load<Sprite>("dailoi");
        queBoi[28] = Resources.Load<Sprite>("daiphu");
        queBoi[29] = Resources.Load<Sprite>("daiphuc");
        queBoi[30] = Resources.Load<Sprite>("daiquy");
        queBoi[31] = Resources.Load<Sprite>("daloc");
        queBoi[32] = Resources.Load<Sprite>("daphuc");
        queBoi[33] = Resources.Load<Sprite>("datho");
        queBoi[34] = Resources.Load<Sprite>("doantu");
        queBoi[35] = Resources.Load<Sprite>("hanhoan");
        queBoi[36] = Resources.Load<Sprite>("hoadao");
        queBoi[37] = Resources.Load<Sprite>("hoamai");
        queBoi[38] = Resources.Load<Sprite>("phatloc");
        queBoi[39] = Resources.Load<Sprite>("phattai");
        queBoi[40] = Resources.Load<Sprite>("quecan");
        queBoi[41] = Resources.Load<Sprite>("quecans");
        queBoi[42] = Resources.Load<Sprite>("quechan");
        queBoi[43] = Resources.Load<Sprite>("quedoai");
        queBoi[44] = Resources.Load<Sprite>("quekham");
        queBoi[45] = Resources.Load<Sprite>("quekhon");
        queBoi[46] = Resources.Load<Sprite>("quely");
        queBoi[47] = Resources.Load<Sprite>("queton");
        queBoi[48] = Resources.Load<Sprite>("truongsinh");
        queBoi[49] = Resources.Load<Sprite>("tuongan");
        queBoi[50] = Resources.Load<Sprite>("vantho");
        queBoi[51] = Resources.Load<Sprite>("yenbinh");
        queBoi[52] = Resources.Load<Sprite>("nham_dan");
        queBoi[53] = Resources.Load<Sprite>("nham_dan");
        queBoi[54] = Resources.Load<Sprite>("nham_dan");
        queBoi[55] = Resources.Load<Sprite>("cattuong");
        queBoi[56] = Resources.Load<Sprite>("daihuu");
        queBoi[57] = Resources.Load<Sprite>("thuancan");
        queBoi[58] = Resources.Load<Sprite>("phucloc");
        queBoi[59] = Resources.Load<Sprite>("hanhthong");
        queBoi[60] = Resources.Load<Sprite>("phuquy");
        queBoi[61] = Resources.Load<Sprite>("tai_loc");
        queBoi[90] = Resources.Load<Sprite>("may_man");

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
