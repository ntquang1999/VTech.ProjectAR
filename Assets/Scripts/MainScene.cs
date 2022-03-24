using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System;
using System.Runtime.InteropServices;


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
    public GameObject hetluot;
    public GameObject ongQueModel;
    AudioController audioController;
    public GameObject musicBtn;
    public GameObject muteBtn;
    public GameObject tutorial;
    public GameObject menu;
    public Toast toast;
    public GameObject confirmPopup;
    bool rollerror = false;
    Vector3 accelarationDir;
    bool allowAccelaration = true;






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
        /*accelarationDir = Input.acceleration;
        if (accelarationDir.sqrMagnitude >= 8f && GameData.allowAccelaration)
            XinQue();*/


        if(!GameData.isARvalid)
        {
            GameData.ToastMessage = "Rất tiếc, thiết bị của bạn không hỗ trợ trải nghiệm chế độ này";
            showPopup();
            GameData.isARvalid = true;
        }
        soLuotLacQue.text =PlayerData.shakeTurn.ToString();
        theLe.text = GameData.theLe;
        waitTime -= Time.deltaTime;
        if (shaking && waitTime <= 1.5)
        {
            //AudioController.playShake();
        }
            
        if (shaking && waitTime<=0 && !rollerror)
        {
            queBoiCanvas.gameObject.SetActive(true);
            shaking = false;
            ongque.SetInteger("shake", 0);
            xinQueBtn.interactable = true;
            ongQueModel.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Escape) && GameData.menuInput)
        {
            exit();
        }

    }

    public void XinQue()
    {
        GameData.allowAccelaration = false;
        xinQueBtn.interactable = false;
        StartCoroutine(APIController.GetTurn_Call((completed) => 
        {
            if (PlayerData.shakeTurn > 0)
            {
                StartCoroutine(APIController.Roll_Call((completed)=> {
                    if (!completed) rollerror = true; else rollerror = false;
                }));
            }
            else
            {
                hetluot.SetActive(true);
                xinQueBtn.interactable = true;
                rollerror = true;
                return;
            }    
        }));
        if(PlayerData.shakeTurn > 0)
        {
            ongque.SetInteger("shake", UnityEngine.Random.Range(1, 3));
            //queBoiCanvas.gameObject.SetActive(true);
            //PlayerData.shakeTurn--;
            shaking = true;
            waitTime = 2f;
            AudioController.playShake();
            particles.SetActive(true);
        }    
        

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
#if UNITY_ANDROID
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("shareOnFacebook", "https://viettel.vn/s/lacque");
#elif UNITY_IOS
        NativePlugins.ShareOnFacebook("https://viettel.vn/s/lacque");
#else
        Application.OpenURL("https://www.facebook.com/share.php?u=https%3A%2F%2Fviettel.vn%2Fs%2Flacque");
#endif
        //UniClipboard.SetText("https://myvt.page.link/Lacque");
        //Application.OpenURL("https://www.facebook.com/share.php?u=https%3A%2F%2Fviettel.vn%2Ftin-tuc%2Fviettel-chinh-thuc-cung-cap-san-pham-vcar-mon-qua-cong-nghe-dip-tet-nguyen-dan%2F15738536");
        //Application.OpenURL(UniClipboard.GetText());
    }

    public void back()
    {
        menu.SetActive(true);
    }

    public void exit()
    {
#if UNITY_IOS
        Application.Unload();
#elif UNITY_ANDROID
        Application.Quit();
#endif
    }


    public void showToastMessage()
    {
        toast.show(GameData.ToastMessage);
    }

    public void showPopup()
    {
        confirmPopup.SetActive(true);
    }

    public void OnClickShare()
    {
    }

}
