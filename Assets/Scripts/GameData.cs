using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct playerProfile
{
    public string number;
    public int zodiacBeastCount;
    public int rank;

    public playerProfile(string inumber, int izodiacBeastCount, int irank)
    {
        number = inumber;
        zodiacBeastCount = izodiacBeastCount;
        rank = irank;
    }
}
public static class GameData
{

    public static List<playerProfile> rankList = new List<playerProfile>();
    public static string theLe;
    public static string[] queBoiDesc = new string[22];

    public static void GenerateGameData()
    {
        for (int i =0;i<10;i++)
        {
            playerProfile profile = new playerProfile("091"+i+".910.JQK", 99 - i, i + 1);
            rankList.Add(profile);
        }
        
        theLe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        
        for (int i = 0; i < 22; i++)
        {
            queBoiDesc[i] = "Nội dung của quẻ bói số " + i + ". Đoạn phía sau đây là viết vào để cho đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ END";
        }   
    }

}
