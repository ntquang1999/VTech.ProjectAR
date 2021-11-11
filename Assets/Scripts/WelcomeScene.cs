using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeScene : MonoBehaviour
{

    public Slider slider;

    [Range(0.0f, 1.0f)]
    public float sliderValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = sliderValue;
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
