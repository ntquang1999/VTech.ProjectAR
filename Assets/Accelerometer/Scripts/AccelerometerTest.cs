using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerTest : MonoBehaviour
{
    int accelTimes = 0;
    float interval = 2;
    [SerializeField] MainScene mainScene;
    private void Start()
    {
        Accelerometer.Instance.OnShake += ActionToRunWhenShakingDevice;
    }
    private void OnDestroy()
    {
        Accelerometer.Instance.OnShake -= ActionToRunWhenShakingDevice;
    }

    private void ActionToRunWhenShakingDevice()
    {
        accelTimes++;
        if(GameData.allowAccelaration && accelTimes>=4)
        {
            mainScene.XinQue();
            accelTimes = 0;
        }
            
    }

    private void Update()
    {
        interval -= Time.deltaTime;
        if(interval<=0)
        {
            interval = 2;
            if (accelTimes > 0)
                accelTimes = 0;
        }
    }
}
