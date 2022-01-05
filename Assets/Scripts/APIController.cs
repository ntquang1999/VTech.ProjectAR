using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public static class APIController
{
    static WWWForm form = new WWWForm();
    static string token;
    public static IEnumerator InitiateAPI(System.Action<bool> onInited)
    {
        WWWForm formIni = new WWWForm();
        formIni.AddField("data", GameData.data);
        formIni.AddField("programCode", "LACQUEAR");
        formIni.AddField("command", "OAuth");
        using (UnityWebRequest www = UnityWebRequest.Post("https://apiv3.viettel.vn/cgvtapiv2/OAuth", formIni))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().showConnectError();
            }
            else
            {
                var json = JSON.Parse(www.downloadHandler.text);
                if (json["errorCode"].Value == "0")
                {
                    token = json["data"]["accessToken"].Value;
                    Debug.LogError(token);
                    onInited?.Invoke(true);
                }
                else
                {

                    Debug.LogError(json["message"].Value);
                    onInited?.Invoke(false);
                }

            }
        }

            
    }

    public static IEnumerator Roll_Call(System.Action<bool> onCompleted)
    {
        WWWForm form = new WWWForm();
        form.AddField("programCode", "LACQUEAR");
        form.AddField("command", "roll");
        UnityWebRequest www = UnityWebRequest.Post("https://apiv3.viettel.vn/cgvtapiv2/roll", form);
        
        www.SetRequestHeader("Authorization", "Bearer " + token);
        yield return www.SendWebRequest();
        
        
        if (www.result != UnityWebRequest.Result.Success)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().showConnectError();
        }
        else
        {
            var json = JSON.Parse(www.downloadHandler.text);
            if (json["errorCode"].Value == "0")
            {               
                PlayerData.shakeTurn = json["data"]["total_turn"];
                GameData.queBoiDescReal = json["data"]["desc"].Value;
                GameData.queBoiIndex = codenToIndex(json["data"]["code"].Value);
                //GameData.queBoiDescReal = json["data"]["desc"].Value;
                Debug.LogError(GameData.queBoiDescReal);
                onCompleted?.Invoke(true);
            }
            else
            {
                Debug.LogError(json["message"].Value);
                onCompleted?.Invoke(false);
            }

        }
    }

    public static IEnumerator History_Call(System.Action<bool> onCompleted)
    {
        WWWForm form = new WWWForm();
        form.AddField("page", "0");
        form.AddField("pageSize", "20");
        form.AddField("programCode", "LACQUEAR");
        form.AddField("command", "rollHistory");
        using (UnityWebRequest www = UnityWebRequest.Post("https://apiv3.viettel.vn/cgvtapiv2/rollHistory", form))
        {
            //Debug.LogError("Bearer " + token);
            www.SetRequestHeader("Authorization", "Bearer " + token);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().showConnectError();
            }
            else
            {
                var json = JSON.Parse(www.downloadHandler.text);
                if (json["errorCode"].Value == "0")
                {
                    Debug.LogError(json["data"]["gifts"][0]);
                    PlayerData.historyItemList.Clear();
                    int maxHistory = json["data"]["total_gift"];
                    if (maxHistory > 20)
                        maxHistory = 20;
                    for (int i=maxHistory-1; i>= 0;i--)
                    {
                        historyItem newItem = new historyItem();
                        newItem.ID = codenToIndex(json["data"]["gifts"][i]["giftCode"]) + 1;
                        newItem.name = json["data"]["gifts"][i]["giftName"].Value;
                        if (newItem.ID == 91)
                            newItem.name = "Quẻ May Mắn";
                        newItem.time = timeConverter(json["data"]["gifts"][i]["winAt"]);
                        newItem.date = dateConverter(json["data"]["gifts"][i]["winAt"]);
                        PlayerData.historyItemList.Add(newItem);
                    }
                    onCompleted?.Invoke(true);
                }
                else
                {
                    Debug.LogError(json["message"].Value);
                    onCompleted?.Invoke(true);
                }

            }
        }
    }

    public static IEnumerator Rank_Call(System.Action<bool> onCompleted)
    {
        WWWForm form = new WWWForm();
        form.AddField("page", "0");
        form.AddField("pageSize", "20");
        form.AddField("programCode", "LACQUEAR");
        form.AddField("command", "rollHistory");
        using (UnityWebRequest www = UnityWebRequest.Post("https://apiv3.viettel.vn/cgvtapiv2/rollHistory", form))
        {
            //Debug.LogError("Bearer " + token);
            www.SetRequestHeader("Authorization", "Bearer " + token);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().showConnectError();
            }
            else
            {
                var json = JSON.Parse(www.downloadHandler.text);
                if (json["errorCode"].Value == "0")
                {
                    GameData.rankList.Clear();
                    for(int i = 0; i<10;i++)
                    {
                        playerProfile profile = new playerProfile(convert84to0(json["data"]["gold_table_v2"][i]["username"].Value), json["data"]["gold_table_v2"][i]["point"], i + 1);
                        GameData.rankList.Add(profile);
                    }    
                    onCompleted?.Invoke(true);
                }
                else
                {
                    Debug.LogError(json["message"].Value);
                    onCompleted?.Invoke(true);
                }

            }
        }
    }

    public static IEnumerator Collection_Call(System.Action<bool> onCompleted)
    {
        WWWForm form = new WWWForm();
        form.AddField("programCode", "LACQUEAR");
        form.AddField("command", "getInsertImg");
        UnityWebRequest www = UnityWebRequest.Post("https://apiv3.viettel.vn/cgvtapiv2/getInsertImg", form);

        www.SetRequestHeader("Authorization", "Bearer " + token);
        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().showConnectError();
        }
        else
        {
            var json = JSON.Parse(www.downloadHandler.text);
            if (json["errorCode"].Value == "0")
            {
                foreach(JSONNode element in json["data"])
                {
                    int index = codenToIndex(element["code"]);
                    if (index <= 12)
                        PlayerData.zodiacBeast[index] = element["total"];
                }    
                onCompleted?.Invoke(true);
            }
            else
            {
                Debug.LogError(json["message"].Value);
                onCompleted?.Invoke(false);
            }

        }
    }

    public static IEnumerator Share_Call(string number, System.Action<bool> onCompleted)
    {
        WWWForm form = new WWWForm();
        form.AddField("programCode", "LACQUEAR");
        form.AddField("command", "addFriend");
        form.AddField("frsMsisdn", number);
        using (UnityWebRequest www = UnityWebRequest.Post("https://apiv3.viettel.vn/cgvtapiv2/addFriend", form))
        {
            //Debug.LogError("Bearer " + token);
            www.SetRequestHeader("Authorization", "Bearer " + token);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().showConnectError();
            }
            else
            {
                var json = JSON.Parse(www.downloadHandler.text);
                Debug.LogError(json["errorCode"].Value);
                if (json["errorCode"].Value == "57")
                {
                    Debug.LogError(json["message"].Value);
                    GameData.ToastMessage = json["message"].Value;
                    onCompleted?.Invoke(true);
                }
                else
                {
                    Debug.LogError(json["message"].Value);
                    GameData.ToastMessage = json["message"].Value;
                    onCompleted?.Invoke(true);
                }

            }
        }
    }

    public static IEnumerator Confirm_Call(string number, System.Action<bool> onCompleted)
    {
        WWWForm form = new WWWForm();
        form.AddField("programCode", "LACQUEAR");
        form.AddField("command", "addFriend");
        form.AddField("frsMsisdn", number);
        using (UnityWebRequest www = UnityWebRequest.Post("https://apiv3.viettel.vn/cgvtapiv2/addFriend", form))
        {
            //Debug.LogError("Bearer " + token);
            www.SetRequestHeader("Authorization", "Bearer " + token);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().showConnectError();
            }
            else
            {
                var json = JSON.Parse(www.downloadHandler.text);
                Debug.LogError(json["errorCode"].Value);
                if (json["errorCode"].Value == "57")
                {
                    Debug.LogError(json["message"].Value);
                    GameData.ToastMessage = json["message"].Value;
                    onCompleted?.Invoke(true);
                }
                else
                {
                    Debug.LogError(json["message"].Value);
                    GameData.ToastMessage = json["message"].Value;
                    onCompleted?.Invoke(true);
                }

            }
        }
    }

    public static IEnumerator GetTurn_Call(System.Action<bool> onCompleted)
    {
        WWWForm form = new WWWForm();
        form.AddField("programCode", "LACQUEAR");
        form.AddField("command", "getTurn");
        using (UnityWebRequest www = UnityWebRequest.Post("https://apiv3.viettel.vn/cgvtapiv2/getTurn", form))
        {
           // Debug.LogError("Bearer " + token);
            www.SetRequestHeader("Authorization", "Bearer " + token);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().showConnectError();
            }
            else
            {
                var json = JSON.Parse(www.downloadHandler.text);
                if (json["errorCode"].Value == "0")
                {
                    //Debug.LogError(json["data"]["turn"]);
                    PlayerData.shakeTurn = json["data"]["turn"];
                    onCompleted?.Invoke(true);
                }
                else
                {
                    Debug.LogError(json["message"].Value);
                    onCompleted?.Invoke(true);
                }    
                    
            }
        }

    }

    public static IEnumerator GetPrize_Call(System.Action<bool> onCompleted)
    {
        WWWForm form = new WWWForm();
        form.AddField("programCode", "LACQUEAR");
        form.AddField("command", "receiveInsertImg");
        form.AddField("imageCode", "TET2022");
        using (UnityWebRequest www = UnityWebRequest.Post("https://apiv3.viettel.vn/cgvtapiv2/receiveInsertImg", form))
        {
            // Debug.LogError("Bearer " + token);
            www.SetRequestHeader("Authorization", "Bearer " + token);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().showConnectError();
            }
            else
            {
                var json = JSON.Parse(www.downloadHandler.text);
                if (json["errorCode"].Value == "0")
                {
                    GameData.ToastMessage = json["message"].Value;
                    onCompleted?.Invoke(true);
                }
                else
                {
                    Debug.LogError(json["message"].Value);
                    GameData.ToastMessage = json["message"].Value;
                    onCompleted?.Invoke(true);
                }

            }
        }

    }

    public static IEnumerator CollectionPrize_Call()
    {
        yield return null;

    }

    public static IEnumerator Rule_Call()
    {
        WWWForm form = new WWWForm();
        form.AddField("programCode", "LACQUEAR");
        form.AddField("command", "rule");
        using (UnityWebRequest www = UnityWebRequest.Post("https://apiv3.viettel.vn/cgvtapiv2/rule", form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + token);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().showConnectError();
            }
            else
            {
                var json = JSON.Parse(www.downloadHandler.text);
                if (json["errorCode"].Value == "0")
                {
                
                    GameData.theLe = json["data"]["content"].Value + "  zzz";
                    Debug.LogError(GameData.theLe) ;
                }
                else
                    Debug.LogError(json["message"].Value);
            }
        }

    }

    public static int codenToIndex(string code)
    { int index = 0;
        foreach(string element in GameData.queBoiCODE)
        {
            if (code == element)
                return index;
            else index++;
        }
        GameData.queBoiDescReal = "Chúc bạn may mắn lần sau!";
        return 90;
    }

    public static string convert84to0(string number)
    {
        if (number != "")
            return "0" + number.Substring(2);
        else return "Chưa xác định";
    }

    public static string timeConverter(string time)
    {
        string year, month, day, hour, minute, second;
        year = time.Substring(0, 4);
        month = time.Substring(4, 2);
        day = time.Substring(6, 2);
        hour = time.Substring(8, 2);
        minute = time.Substring(10, 2);
        second = time.Substring(12, 2);

        return hour + ":" + minute + ":" + second;
    }

    public static string dateConverter(string time)
    {
        string year, month, day, hour, minute, second;
        year = time.Substring(0, 4);
        month = time.Substring(4, 2);
        day = time.Substring(6, 2);
        hour = time.Substring(8, 2);
        minute = time.Substring(10, 2);
        second = time.Substring(12, 2);

        return day + "/" + month + "/" + year;
    }

}
