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
    public static string[] tutorialDesc = new string[8];

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
        
        for (int i = 0; i < 22; i++)
        {
            queBoiDesc[i] = "Xuân này hơn hẳn mấy xuân qua\nPhúc lộc đưa nhau đến từng nhà\nVài lời cung chúc tân niên mới\nVạn sự an khang vạn sự lành";
            //queBoiDesc[i] = "Nội dung của quẻ bói số " + i + ". Đoạn phía sau đây là viết vào để cho đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ END";
        }
        

        tutorialDesc[0] = "Ấn vào đây để bắt đầu lượt xin quẻ. Mỗi quẻ tương ứng một phần quà hấp dẫn";
        tutorialDesc[1] = "Quá trình xin quẻ bạn có thể nhận được linh thú. Kiểm tra xem bạn có những linh thú nào rồi nhé";
        tutorialDesc[2] = "Bạn cũng có thể kiểm tra lại các phần thưởng mình đã lắc được ở đây";
        tutorialDesc[3] = "Cùng nhau đua top với mọi người. Nhấn vào đây để xem bảng xếp hạng";
        tutorialDesc[4] = "Đừng quên rủ bạn bè cùng chơi thử để nhận thêm lượt lắc quẻ nhé";
        tutorialDesc[5] = "Lấy đường link chia sẻ sự kiện tại đây";
        tutorialDesc[6] = "Thể lệ và thời gian diễn ra chương trình bạn sẽ xem ở đây";
        tutorialDesc[7] = "Và cuối cùng là tính năng đặc biệt AR. AR mode giúp bạn có trải nghiệm lắc quẻ sống động như thật";

    }

}
