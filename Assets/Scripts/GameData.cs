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
    public static string ToastMessage;
    public static int queBoiIndex;
    public static string queBoiDescReal;
    public static string data;
    public static bool confirmed = false;

    public static bool menuInput = true;
    public static string[] queBoiCODE = new string[]
    {
        "CHUOT",
        "TRAU",
        "HO",
        "MEO",
        "RONG",
        "RAN",
        "NGUA",
        "DE",
        "KHI",
        "GA",
        "CHO",
        "LON",
        "THECAO50K",
        "HANHPHUC",
        "THECAO20K",
        "THECAO10K",
        "DIENMAYXANH200K",
        "1GBDATA",
        "SUMVAY1",
        "10PHUTNOIMANG",
        "VUIVE",
        "=======================================",
        "ANLANH",
        "ANYEN",
        "DAIAN",
        "SHOPEE50K",
        "DAILOC",
        "DAILOI",
        "DAIPHU",
        "DAIPHUC",
        "DAIQUY",
        "DALOC",
        "DAPHUC",
        "DATHO",
        "TIKI50K",
        "HANHOAN",
        "HOADAO",
        "HOAMAI",
        "PHATLOC",
        "PHATTAI",
        "CAN",
        "QUECAN",
        "CHAN",
        "DOAI",
        "KHAM",
        "KHON",
        "LY",
        "TON",
        "TRUONGSINH",
        "TUONGAN",
        "VANTHO",
        "YENBINH",
        "GOLDENGATE100K",
        "REDSUN100K",
        "CGV105K",
        "CATTUONG",
        "DAIHUU",
        "THUANCAN",
        "PHUCLOC",
        "HANHTHONG",
        "GRAB30K",
        "TAILOC",
        "LUCKY"

    };
    public static string[] tutorialDesc = new string[6];

    public static void GenerateGameData()
    {
        for (int i =0;i<10;i++)
        {
            playerProfile profile = new playerProfile("091"+i+".910.JQK", 99 - i, i + 1);
            rankList.Add(profile);
        }
        
        
        //for (int i = 0; i < 22; i++)
        //{
        //    //queBoiDesc[i] = "Xuân này hơn hẳn mấy xuân qua\nPhúc lộc đưa nhau đến từng nhà\nVài lời cung chúc tân niên mới\nVạn sự an khang vạn sự lành";
        //    //queBoiDesc[i] = "Nội dung của quẻ bói số " + i + ". Đoạn phía sau đây là viết vào để cho đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ END";
        //}

        
        tutorialDesc[0] = "Ấn vào đây để bắt đầu lượt xin quẻ. Mỗi quẻ sẽ tương ứng với 1 phần quà hấp dẫn";
        tutorialDesc[1] = "Quá trình xin quẻ bạn có thể nhận được Linh thú. Kiểm tra xem bạn đã sưu tập được những linh thú nào tại đây";
        tutorialDesc[2] = "Bạn cũng có thể kiểm tra lại các phần thưởng, linh thú mà mình đã nhận được ở đây";
        tutorialDesc[3] = "Đừng quên rủ bạn bè cùng chơi với mình nhé, chúng mình có phần thưởng dành tặng bạn đó";
        tutorialDesc[4] = "Cụ thể nội dung, thời gian diễn ra chương trình tại đây";
        tutorialDesc[5] = "AR Mode sẽ giúp bạn trải nghiệm cảm giác lắc quẻ sống động như thật. Trải nghiệm công nghệ AR mode ngay thôi!";
       
    }

}
