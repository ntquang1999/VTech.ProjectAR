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

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        PlayerData.GeneratePlayerData();
    }

    // Update is called once per frame
    void Update()
    {

        //slider.value = sliderValue;
    }

    private void FixedUpdate()
    {
        debug_fakeWaitTime -= Time.fixedDeltaTime;
        slider.value = 5 - debug_fakeWaitTime;
        if (debug_fakeWaitTime <= 4)
            gameController.loadScene(1);
    }

    public void debug_addProgress()
    {
        if(sliderValue<1.0f)
        sliderValue += 0.2f;
    }

    public void debug_reduceProgress()
    {
        if(sliderValue>=0.2f)
        sliderValue -= 0.2f;
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
