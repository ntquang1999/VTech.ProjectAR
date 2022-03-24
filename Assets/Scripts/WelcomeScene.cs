using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeScene : MonoBehaviour
{

    public Slider slider;
    public static GameController gameController;
    [SerializeField] float debug_fakeWaitTime = 5;

    [Range(0.0f, 1.0f)]
    public float sliderValue;
    bool isDone = false;
    bool isLoading = false;
    float timeout = 10.0f;

    // Start is called before the first frame update

    private void Awake()
    {
        GameData.ResetGameData();
        PlayerData.ResetPlayerData();
    }

    void Update()
    {
        Debug.LogError("Waiting..., Data: " + GameData.data);
        if (GameData.data != null && !isLoading)
        {
            Debug.LogError(GameData.data);
            loadData();
            isLoading = true;
        }
    }

    void loadData()
    {

        gameController = FindObjectOfType<GameController>();
        PlayerData.GeneratePlayerData();
        GameData.GenerateGameData();
        GameData.getQueBoiImage();
        //LoadMain();
        StartCoroutine(APIController.InitiateAPI((inited) =>
        {
            isDone = inited;
            
            if(inited)
            {
                StartCoroutine(APIController.GetTurn_Call((completed) => {
                    if(completed)
                    {
                        StartCoroutine(APIController.Rule_Call((completed) => { }));
                        StartCoroutine(APIController.FirstLogin_Call((completed) => {
                            StartCoroutine(LoadMainScene());
                        }));

                        
                    }    
                        
                }));
                
                
            }    
            
        }));
        
        
    }

    private IEnumerator LoadMainScene()
    {
        var a = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        a.allowSceneActivation = false;
        while (!a.isDone)
        {
            slider.value = a.progress * 0.9f;
            //Debug.LogError(a.progress);
            if (a.progress >= 0.9f)
                if (isDone)
                {
                    //Debug.LogError("AAAAAAAAAA");
                    slider.value = 1;
                    a.allowSceneActivation = true;
                    //yield return null;
                }
            yield return null;
        }


        //yield return a;
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        //debug_fakeWaitTime -= Time.fixedDeltaTime;
        //slider.value = 5 - debug_fakeWaitTime;
        //if (debug_fakeWaitTime <= 4)
        //    gameController.loadScene(1);
    }

    public void debug_addProgress()
    {
        if (sliderValue < 1.0f)
            sliderValue += 0.2f;
    }

    public void debug_reduceProgress()
    {
        if (sliderValue >= 0.2f)
            sliderValue -= 0.2f;
    }

    public void LoadMain()
    {
        loadScene(1);
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
