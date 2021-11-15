using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData
{
    string phoneNumber;
    string name;
    int userTier;
    List<int> historyItemID;
    int[] zodiacBeast = new int[12];
    
    PlayerData()
    {
        phoneNumber = "0123456789";
        name = "Dummy Player";
        userTier = 0;
        historyItemID.Add(1);
        zodiacBeast[0] = 1;
    }

    PlayerData(string phoneNumber, string name, int userTier, List<int> historyItemID, int[] zodiacBeast)
    {
        this.phoneNumber = phoneNumber;
        this.name = name;
        this.userTier = userTier;
        this.historyItemID = historyItemID;
        this.zodiacBeast = zodiacBeast;
    }

    void AddItem(int ID)
    {
        historyItemID.Add(ID);
        if(isZodiacBeast())
        {
            zodiacBeast[ID]++;
        }
    }
    
    void LoadPlayerData()
    {
        //Call API to get the data
    }

    void SavePlayerData()
    {
        //Call API to save the data
    }

    bool isZodiacBeast()
    {
        return true;
    }
}
