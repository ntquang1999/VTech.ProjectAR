using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toast : MonoBehaviour
{
    public Text text;

    public void show()
    {
        this.GetComponent<Animator>().Play("ToastAnim",0,0);
    }    
}
