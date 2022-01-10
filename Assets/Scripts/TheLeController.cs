using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        GameData.menuInput = false;
    }

    public void back()
    {
        GameData.menuInput = true;
    }    
}
