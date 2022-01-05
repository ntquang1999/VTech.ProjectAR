

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

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

    private void Start()
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
        StartCoroutine(APIController.GetTurn_Call((completed) =>
        {
            if (controller.objectPlaced && PlayerData.shakeTurn > 0)
            {
                placedObject = GameObject.FindGameObjectWithTag("PlacedObject").GetComponent<PlacedObject>();
                StartCoroutine(APIController.Roll_Call((completed) => {
                    placedObject.shake();
                }));
                
                xinQueBtn.interactable = false;
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
