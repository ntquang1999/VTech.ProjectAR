using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARReset : MonoBehaviour
{
    public ARScene aRScene;
    private void OnDisable()
    {
        aRScene.reset();
    }
}
