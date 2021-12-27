using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public static class APIController
{
    static WWWForm form = new WWWForm();
    public static IEnumerator InitiateAPI()
    {
        form.AddField("data", "AR");
        form.AddField("programCode", "1233");
        form.AddField("command", "OAuth");
        using (UnityWebRequest www = UnityWebRequest.Post("http://fishhunter.ugame.vn/demo_api/api.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                var json = JSON.Parse(www.downloadHandler.text);
                if (json["errorCode"].Value == "0")
                {
                    Debug.LogError(json["data"]["accessToken"].Value);
                }
                else
                    Debug.LogError(json["message"].Value);
            }
        }

            
    }

    public static IEnumerator Roll_Call()
    {
        //form.AddField("data", "AR");
        //form.AddField("programCode", "1233");
        //form.AddField("command", "OAuth");
        UnityWebRequest www = UnityWebRequest.Post("http://fishhunter.ugame.vn/demo_api/api.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            var json = JSON.Parse(www.downloadHandler.text);
            if (json["errorCode"].Value == "0")
            {
                //Debug.LogError(json["data"]["accessToken"].Value);
                Debug.LogError("RollCall");
            }
            else
            {
                //Debug.LogError(json["message"].Value);
            }

        }
    }

    public static IEnumerator History_Call()
    {
        form.AddField("data", "AR");
        UnityWebRequest www = UnityWebRequest.Post("http://fishhunter.ugame.vn/demo_api/api.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            var json = JSON.Parse(www.downloadHandler.text);
            if (json["errorCode"].Value == "0")
            {
                //Debug.LogError(json["data"]["accessToken"].Value);
            }
            else
            {
                //Debug.LogError(json["message"].Value);
            }

        }
    }

    public static IEnumerator Rank_Call()
    {
        form.AddField("data", "AR");
        UnityWebRequest www = UnityWebRequest.Post("http://fishhunter.ugame.vn/demo_api/api.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            var json = JSON.Parse(www.downloadHandler.text);
            if (json["errorCode"].Value == "0")
            {
                //Debug.LogError(json["data"]["accessToken"].Value);
            }
            else
            {
                //Debug.LogError(json["message"].Value);
            }

        }
    }

    public static IEnumerator Collection_Call()
    {
        form.AddField("data", "AR");
        UnityWebRequest www = UnityWebRequest.Post("http://fishhunter.ugame.vn/demo_api/api.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            var json = JSON.Parse(www.downloadHandler.text);
            if (json["errorCode"].Value == "0")
            {
                //Debug.LogError(json["data"]["accessToken"].Value);
            }
            else
            {
                //Debug.LogError(json["message"].Value);
            }

        }
    }

    public static IEnumerator Share_Call()
    {
        form.AddField("data", "AR");
        UnityWebRequest www = UnityWebRequest.Post("http://fishhunter.ugame.vn/demo_api/api.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            var json = JSON.Parse(www.downloadHandler.text);
            if (json["errorCode"].Value == "0")
            {
                //Debug.LogError(json["data"]["accessToken"].Value);
            }
            else
            {
                //Debug.LogError(json["message"].Value);
            }

        }
    }

}
