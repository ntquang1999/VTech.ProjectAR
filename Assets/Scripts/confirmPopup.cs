using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class confirmPopup : MonoBehaviour
{

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameData.ToastMessage;
    }

    public void okClick()
    {
            gameObject.SetActive(false);
    }    

}
