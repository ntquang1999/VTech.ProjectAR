using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    public GameObject connectError;
    public GameObject connectError2;

    [SerializeField] bool standalone = true;

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
        //if(standalone)
            //Invoke("Fake", 2);
        Application.targetFrameRate = 60;
    }

    void Fake()
    {
        //receiveData("2bmrcgxoybkzpan5u01645000194888");
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

    public void showConnectErrorLoading()
    {

        connectError2.SetActive(true);
    }

    public void receiveData(string receive)
    {
        GameData.data = receive;
        Debug.LogError("Receive: " + receive);
        Debug.LogError("Receive: " + GameData.data);
    }

    public void receiveARCheck(bool isValid)
    {
        GameData.isARvalid = isValid;
    }

    public void exit()
    {
#if UNITY_IOS
        Application.Unload();
#elif UNITY_ANDROID
        Application.Quit();
#endif
    }
}
