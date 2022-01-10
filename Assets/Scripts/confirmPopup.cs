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

    private void OnEnable()
    {
        GameData.menuInput = false;
    }

    public void okClick()
    {
        GameData.menuInput = true;
        gameObject.SetActive(false);
    }    

}
