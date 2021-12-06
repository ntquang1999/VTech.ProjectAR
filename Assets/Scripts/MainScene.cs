using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public static GameController gameController;
    public Canvas queBoiCanvas;
    public Text soLuotLacQue;
    public Text theLe;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        theLe.text = GameData.theLe;
    }

    // Update is called once per frame
    void Update()
    {
        soLuotLacQue.text =PlayerData.shakeTurn.ToString();
    }

    public void XinQue()
    {
        if (PlayerData.shakeTurn > 0)
        {
            queBoiCanvas.gameObject.SetActive(true);
            PlayerData.shakeTurn--;
        }                 
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
