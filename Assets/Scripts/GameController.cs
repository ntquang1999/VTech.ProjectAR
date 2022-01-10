using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    public GameObject connectError;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else Destroy(gameObject);
        //PlayerData.GeneratePlayerData();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Fake", 2);
        Application.targetFrameRate = 60;
    }

    void Fake()
    {
        receiveData("2bmrcgxcc2kvarti821635414922369");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void showConnectError()
    {
        connectError.SetActive(true);
    }  
    
    public void receiveData(string receive)
    {
        GameData.data = receive;
        Debug.LogError("Receive: " + receive);
        Debug.LogError("Receive: " + GameData.data);
    }

    public void exit()
    {
        Application.Unload();
    }

}
