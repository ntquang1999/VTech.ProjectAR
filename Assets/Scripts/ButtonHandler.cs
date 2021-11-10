using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{

    GameObject ongThe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ongThe = GameObject.FindGameObjectWithTag("OngThe");
    }

    public void scaleUp()
    {
        ongThe.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void scaleDown()
    {
        ongThe.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }

}
