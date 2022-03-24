

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARScene : MonoBehaviour
{
    public GameObject tiger;
    public GameObject ongQue;
    public GameObject queBoiCanvas;
    public GameObject particles;
    //public Animator ongQueAnimator;
    public PlayerController controller;
    PlacedObject placedObject;
    public bool isFinishedPlaying = false;
    public Text soLuot;
    public Button xinQueBtn;
    AudioController audioController;
    public GameObject musicBtn;
    public GameObject muteBtn;
    [SerializeField] ARSession m_Session;

    IEnumerator Start()
    {
        if ((ARSession.state == ARSessionState.None) ||
            (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            GameData.isARvalid = false;
            SceneManager.LoadScene(1);
        }
        else
        {
            // Start the AR session
            m_Session.enabled = true;
        }
    }

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioController>();
        if(audioController.getState())
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

    void Update()
    {
        soLuot.text = PlayerData.shakeTurn.ToString();
        if (Input.GetKeyUp(KeyCode.Escape) && GameData.menuInput)
        {
            loadScene(1);
        }
    }

    public void showCanvas()
    {
        queBoiCanvas.SetActive(true);
    }

    public void reset()
    {
        placedObject.reset();
        xinQueBtn.interactable = true;
    }
    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void shake()
    {
        xinQueBtn.interactable = false;
        
        StartCoroutine(APIController.GetTurn_Call((completed) =>
        {
            if (controller.objectPlaced && PlayerData.shakeTurn > 0)
            {
                placedObject = GameObject.FindGameObjectWithTag("PlacedObject").GetComponent<PlacedObject>();
                StartCoroutine(APIController.Roll_Call((completed) => {
                    placedObject.shake();
                    AudioController.playShake();
                }));               
            }
        }));
        
    }  
    
    public void mute()
    {
        audioController.mute();
    }

    public void unmute()
    {
        audioController.unmute();
    }

}
