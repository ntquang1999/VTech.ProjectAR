using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueBoi : MonoBehaviour
{


    public int queBoiIndex = 0;
    Sprite[] queBoi = new Sprite[10];
    string[] desc = new string[10];
    public Text queDesc;

    private void Awake()
    {
        getQueBoiImage();
        getString();
    }

    private void OnEnable()
    {
        queBoiIndex = Random.Range(0, 9);
        gameObject.GetComponent<Image>().sprite = queBoi[queBoiIndex];
        gameObject.GetComponent<Image>().SetNativeSize();
        queDesc.text = desc[queBoiIndex];
        if (queBoiIndex == 5)
            PlayerData.shakeTurn += 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getQueBoiImage()
    {
        queBoi[0] = Resources.Load<Sprite>("SanPham/2DART/Popup/QueBoi/binh_an");
        queBoi[1] = Resources.Load<Sprite>("SanPham/2DART/Popup/QueBoi/hanh_phuc");
        queBoi[2] = Resources.Load<Sprite>("SanPham/2DART/Popup/QueBoi/hoan_hi");
        queBoi[3] = Resources.Load<Sprite>("SanPham/2DART/Popup/QueBoi/may_man");
        queBoi[4] = Resources.Load<Sprite>("SanPham/2DART/Popup/QueBoi/nham_dan");
        queBoi[5] = Resources.Load<Sprite>("SanPham/2DART/Popup/QueBoi/suc_khoe");
        queBoi[6] = Resources.Load<Sprite>("SanPham/2DART/Popup/QueBoi/sum_vay");
        queBoi[7] = Resources.Load<Sprite>("SanPham/2DART/Popup/QueBoi/tai_loc");
        queBoi[8] = Resources.Load<Sprite>("SanPham/2DART/Popup/QueBoi/vui_ve");
        queBoi[9] = Resources.Load<Sprite>("SanPham/2DART/Popup/QueBoi/vuong_phat");
    }

    void getString()
    {
        //Dummy string
        desc[0] = "Bạn nhận được một Iphone 14 pro max";
        desc[1] = "Bạn nhận được 1000 phút gọi liên mạng";
        desc[2] = "Bạn nhận được 500GB data không giới hạn";
        desc[3] = "Bạn nhận được 10000 SMS";
        desc[4] = "Bạn nhận được một con vịt xòe ra 2 cái cánh";
        desc[5] = "Bạn nhận được 3 lượt lắc quẻ";
        desc[6] = "Bạn nhận được một bộ linh thú đầy đủ";
        desc[7] = "Bạn nhận được một phần quà đặc biệt";
        desc[8] = "Bạn nhận được một bánh chưg";
        desc[9] = "Bạn nhận được null";

    }

}
