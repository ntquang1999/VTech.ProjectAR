using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct historyItem
{
    public int ID;
    public string name;
    public string time;
    public string date;
}
public static class PlayerData
{
    

    public static string phoneNumber;
    public static string name;
    public static int userTier;
    public static int shakeTurn;
    public static List<historyItem> historyItemList = new List<historyItem>();
    public static int[] zodiacBeast = new int[12];
    public static bool firstTime = true;
    public static void GeneratePlayerData()
    {
        phoneNumber = "0123456789";
        name = "Dummy Player";
        userTier = 0;
        shakeTurn = 0;
        firstTime = false;
    }

    public static void ResetPlayerData()
    {
        phoneNumber = "0123456789";
        name = "Dummy Player";
        userTier = 0;
        shakeTurn = 0;
        firstTime = false;
    }

    public static void AddItem(historyItem item)
    {
        historyItemList.Add(item);
        if(isZodiacBeast())
        {
            zodiacBeast[item.ID]++;
        }
    }

    public static void LoadPlayerData()
    {
        //Call API to get the data
    }

    public static void SavePlayerData()
    {
        //Call API to save the data
    }

    public static bool isZodiacBeast()
    {
        return true;
    }
}
