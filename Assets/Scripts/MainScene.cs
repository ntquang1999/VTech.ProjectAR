using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;

public class MainScene : MonoBehaviour
{
    public static GameController gameController;
    public Canvas queBoiCanvas;
    public Text soLuotLacQue;
    public Text theLe;
    public Animator ongque;
    bool shaking = false;
    float waitTime = 0;
    public Button xinQueBtn;
    public GameObject particles;
    public GameObject ongQueModel;
    AudioController audioController;
    public GameObject musicBtn;
    public GameObject muteBtn;
    public GameObject tutorial;
    public GameObject menu;
    public Toast toast;
    public GameObject confirmPopup;



    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        //theLe = GameObject.FindGameObjectWithTag("thele").GetComponent<Text>();
        
        //GameData.GenerateGameData();
        //PlayerData.GeneratePlayerData();
        
        if (PlayerData.firstTime)
        {
            tutorial.SetActive(true);
            
        }
        audioController = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioController>();
        if (audioController.getState())
        {
            musicBtn.SetActive(true);
            muteBtn.SetActive(false);
        }
        else
        {
            musicBtn.SetActive(false);
            muteBtn.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        soLuotLacQue.text =PlayerData.shakeTurn.ToString();
        theLe.text = GameData.theLe;
        waitTime -= Time.deltaTime;
        if (shaking && waitTime<=0)
        {
            queBoiCanvas.gameObject.SetActive(true);
            shaking = false;
            ongque.SetInteger("shake", 0);
            xinQueBtn.interactable = true;
            ongQueModel.SetActive(false);
        }
           
    }

    public void XinQue()
    {
        StartCoroutine(APIController.GetTurn_Call((completed) => 
        {
            if (PlayerData.shakeTurn > 0)
            {
                StartCoroutine(APIController.Roll_Call((completed)=> {
                    ongque.SetInteger("shake", Random.Range(1, 3));
                    //queBoiCanvas.gameObject.SetActive(true);
                    //PlayerData.shakeTurn--;
                    shaking = true;
                    waitTime = 2f;
                    xinQueBtn.interactable = false;
                    particles.SetActive(true);
                }));
                

            }
        }));
                     
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void mute()
    {
        audioController.mute();
    }

    public void unmute()
    {
        audioController.unmute();
    }

    public void share()
    {
        UniClipboard.SetText("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        Application.OpenURL(UniClipboard.GetText());
    }    

    public void back()
    {
        menu.SetActive(true);
    }

    public void Unload()
    {
        Application.Unload();
    }

    public void showToastMessage()
    {
        toast.show(GameData.ToastMessage);
    }

    public void showPopup()
    {
        confirmPopup.SetActive(true);
    }

}
