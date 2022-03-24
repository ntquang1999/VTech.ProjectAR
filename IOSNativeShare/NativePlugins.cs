using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class NativePlugins : MonoBehaviour
{
    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void _ShareOnFacebook(string shareLink);

    public static void ShareOnFacebook(string shareLink)
    {
        _ShareOnFacebook(shareLink);
    }
    #endif
}
