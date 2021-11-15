using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueBoi : MonoBehaviour
{


    public int queBoiIndex = 0;
    Sprite[] queBoi = new Sprite[10];
    
    // Start is called before the first frame update
    void Start()
    {
        getQueBoiImage();      
    }

    private void OnEnable()
    {
        queBoiIndex = Random.Range(0, 9);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().sprite = queBoi[queBoiIndex];
        gameObject.GetComponent<Image>().SetNativeSize();
    }

    void getQueBoiImage()
    {
        queBoi[0] = Resources.Load<Sprite>("Arts/2DART/0711/QueBoi/BINHAN");
        queBoi[1] = Resources.Load<Sprite>("Arts/2DART/0711/QueBoi/HANHPHUC");
        queBoi[2] = Resources.Load<Sprite>("Arts/2DART/0711/QueBoi/HOANHI");
        queBoi[3] = Resources.Load<Sprite>("Arts/2DART/0711/QueBoi/MAYMAN");
        queBoi[4] = Resources.Load<Sprite>("Arts/2DART/0711/QueBoi/NHAMDAN");
        queBoi[5] = Resources.Load<Sprite>("Arts/2DART/0711/QueBoi/SUCKHOE");
        queBoi[6] = Resources.Load<Sprite>("Arts/2DART/0711/QueBoi/SUMVAY");
        queBoi[7] = Resources.Load<Sprite>("Arts/2DART/0711/QueBoi/TAILOC");
        queBoi[8] = Resources.Load<Sprite>("Arts/2DART/0711/QueBoi/VUIVE");
        queBoi[9] = Resources.Load<Sprite>("Arts/2DART/0711/QueBoi/VUONGPHAT");
    }

}
