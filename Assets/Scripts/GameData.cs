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
    public static string[] queBoiDesc = new string[] {
        "Bạn đã nhận được linh thú Tí tượng trưng cho một con chuột. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Sửu tượng trưng cho một con trâu. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Dần tượng trưng cho một con hổ. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Mão tượng trưng cho một con mòe. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Thìn tượng trưng cho một con rồng. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Tỵ tượng trưng cho một con rắn. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Ngọ tượng trưng cho một con ngựa. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Mùi tượng trưng cho một con dê. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Thân tượng trưng cho một con khỉ. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Dậu tượng trưng cho một con gà. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Tuất tượng trưng cho một con chó. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn đã nhận được linh thú Hợi tượng trưng cho một con lợn. Hay tiếp tục sưu tập thêm và nhận thưởng nhé!",
        "Bạn nhận được 10 phút gọi nội mạng",
        //Thơ 
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        ""



    };
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
        "10PHUTNOIMANG",
        "1GBDATA",
        "THECAO10K",
        "THECAO20K",
        "THECAO50K",
        "THECAO500K",
        "GRAB30K",
        "TIKI50K",
        "SHOPEE50K",
        "GOLDENGATE100K",
        "REDSUN100K",
        "CGV105K",
        "DIENMAYXANH200K",
        "VUIVE",
        "HANHPHUC",
        "SUMVAY1",
        "CATTUONG",
        "ANLANH",
        "VANTHO",
        "DAIPHUC",
        "DAILOI",
        "DAIPHU",
        "DAIQUY",
        "ANYEN",
        "TRUONGSINH",
        "HOADAO",
        "HOAMAI",
        "TUONGAN",
        "HANHOAN" 

    };
    public static string[] tutorialDesc = new string[6];

    public static void GenerateGameData()
    {
        for (int i =0;i<10;i++)
        {
            playerProfile profile = new playerProfile("091"+i+".910.JQK", 99 - i, i + 1);
            rankList.Add(profile);
        }
        
        theLe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." +
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." +
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        
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
