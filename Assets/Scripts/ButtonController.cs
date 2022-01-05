using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    [SerializeField] GameObject lichsu;
    [SerializeField] GameObject bxh;
    [SerializeField] GameObject bst;
    [SerializeField] GameObject thele;
    [SerializeField] GameObject moiban;
    [SerializeField] GameObject menu;
    GameObject goLS;
    GameObject goBXH;
    GameObject goBST;
    GameObject goTL;
    public GameObject goIV;

    bool haslichsu = false;
    bool hasbxh = false;
    bool hasbst = false;
    bool hasthele = false;
    bool hasmoiban = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lichSu()
    {
        if (!haslichsu)
            goLS = Instantiate(lichsu);
        else
            goLS.SetActive(true);
        haslichsu = true;
    }
    public void BXH()
    {
        if (!hasbxh)
            goBXH = Instantiate(bxh);
        else
            goBXH.SetActive(true);
        hasbxh = true;
    }
    public void Invite()
    {
        if (!hasmoiban)
            goIV = Instantiate(moiban);
        else
            goIV.SetActive(true);
        hasmoiban = true;
    }
    public void TheLe()
    {
        if (!hasthele)
            goTL = Instantiate(thele);
        else
            goTL.SetActive(true);
        hasthele = true;
    }
    public void BST()
    {
        if (!hasbst)
           goBST =  Instantiate(bst);
        else
            goBST.SetActive(true);
        hasbst = true;
    }

}
