

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARScene : MonoBehaviour
{
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
        
    }

    void Update()
    {
    }

    public void showCanvas()
    {
    }

    public void reset()
    {
    }
    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void shake()
    {
        
        
    }  
    
    public void mute()
    {
    }

    public void unmute()
    {
    }

}
