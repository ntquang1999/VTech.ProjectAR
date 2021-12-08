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

    void Update()
    {

    }

    public void showCanvas()
    {
        queBoiCanvas.SetActive(true);
    }

    public void reset()
    {
        placedObject.reset();
    }
    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void shake()
    {
        if (controller.objectPlaced)
        {
            placedObject = GameObject.FindGameObjectWithTag("PlacedObject").GetComponent<PlacedObject>();
            placedObject.shake();  
        }
    }    

}
