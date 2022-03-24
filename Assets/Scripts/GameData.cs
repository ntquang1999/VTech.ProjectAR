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
    public static bool allowAccelaration = true;
    public static int collectionPrizeTime = 0;
    public static bool menuInput = true;
    public static bool isARvalid = true;
    public static Sprite[] queBoi = new Sprite[100];
    public static Sprite[] queBoiHistory = new Sprite[100];
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
    public static string[] tutorialDesc = new string[]
    {
        "Ấn vào đây để bắt đầu lượt xin quẻ. Mỗi quẻ sẽ tương ứng với 1 phần quà hấp dẫn",
        "Quá trình xin quẻ bạn có thể nhận được Linh thú. Kiểm tra xem bạn đã sưu tập được những linh thú nào tại đây",
        "Bạn cũng có thể kiểm tra lại các phần thưởng, linh thú mà mình đã nhận được ở đây",
        "Đừng quên rủ bạn bè cùng chơi với mình nhé, phần thưởng bất ngờ đang chờ bạn đó",
        "Tìm hiểu nội dung thể lệ, thời gian diễn ra chương trình tại đây",
        "AR Mode sẽ giúp bạn trải nghiệm cảm giác lắc quẻ sống động như thật. Trải nghiệm công nghệ AR mode ngay thôi!",
        "Chia sẻ trò chơi này đến bạn bè ngay!",
    };

    public static void GenerateGameData()
    {
        for (int i = 0; i < 10; i++)
        {
            playerProfile profile = new playerProfile("091" + i + ".910.JQK", 99 - i, i + 1);
            rankList.Add(profile);
        }

        allowAccelaration = true;
        //for (int i = 0; i < 22; i++)
        //{
        //    //queBoiDesc[i] = "Xuân này hơn hẳn mấy xuân qua\nPhúc lộc đưa nhau đến từng nhà\nVài lời cung chúc tân niên mới\nVạn sự an khang vạn sự lành";
        //    //queBoiDesc[i] = "Nội dung của quẻ bói số " + i + ". Đoạn phía sau đây là viết vào để cho đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ đủ đủ đủ đủ đủđủ đủ END";
        //}

    }

    public static void getQueBoiImage()
    {
        for(int i = 1; i<=63;i++ )
        {
            queBoiHistory[i] = Resources.Load<Sprite>("History/" + i);
        }
        queBoi[0] = Resources.Load<Sprite>("1");
        queBoi[1] = Resources.Load<Sprite>("2");
        queBoi[2] = Resources.Load<Sprite>("3");
        queBoi[3] = Resources.Load<Sprite>("4");
        queBoi[4] = Resources.Load<Sprite>("5");
        queBoi[5] = Resources.Load<Sprite>("6");
        queBoi[6] = Resources.Load<Sprite>("7");
        queBoi[7] = Resources.Load<Sprite>("8");
        queBoi[8] = Resources.Load<Sprite>("9");
        queBoi[9] = Resources.Load<Sprite>("10");
        queBoi[10] = Resources.Load<Sprite>("11");
        queBoi[11] = Resources.Load<Sprite>("12");
        queBoi[12] = Resources.Load<Sprite>("binh_an");
        queBoi[13] = Resources.Load<Sprite>("hanh_phuc");
        queBoi[14] = Resources.Load<Sprite>("hoan_hi");
        queBoi[15] = Resources.Load<Sprite>("may_man");
        queBoi[16] = Resources.Load<Sprite>("nham_dan");
        queBoi[17] = Resources.Load<Sprite>("suc_khoe");
        queBoi[18] = Resources.Load<Sprite>("sum_vay");
        queBoi[19] = Resources.Load<Sprite>("tai_loc");
        queBoi[20] = Resources.Load<Sprite>("vui_ve");
        queBoi[21] = Resources.Load<Sprite>("vuong_phat");
        queBoi[22] = Resources.Load<Sprite>("anlanh");
        queBoi[23] = Resources.Load<Sprite>("anyen");
        queBoi[24] = Resources.Load<Sprite>("daian");
        queBoi[25] = Resources.Load<Sprite>("daicat");
        queBoi[26] = Resources.Load<Sprite>("dailoc");
        queBoi[27] = Resources.Load<Sprite>("dailoi");
        queBoi[28] = Resources.Load<Sprite>("daiphu");
        queBoi[29] = Resources.Load<Sprite>("daiphuc");
        queBoi[30] = Resources.Load<Sprite>("daiquy");
        queBoi[31] = Resources.Load<Sprite>("daloc");
        queBoi[32] = Resources.Load<Sprite>("daphuc");
        queBoi[33] = Resources.Load<Sprite>("datho");
        queBoi[34] = Resources.Load<Sprite>("doantu");
        queBoi[35] = Resources.Load<Sprite>("hanhoan");
        queBoi[36] = Resources.Load<Sprite>("hoadao");
        queBoi[37] = Resources.Load<Sprite>("hoamai");
        queBoi[38] = Resources.Load<Sprite>("phatloc");
        queBoi[39] = Resources.Load<Sprite>("phattai");
        queBoi[40] = Resources.Load<Sprite>("quecan");
        queBoi[41] = Resources.Load<Sprite>("quecans");
        queBoi[42] = Resources.Load<Sprite>("quechan");
        queBoi[43] = Resources.Load<Sprite>("quedoai");
        queBoi[44] = Resources.Load<Sprite>("quekham");
        queBoi[45] = Resources.Load<Sprite>("quekhon");
        queBoi[46] = Resources.Load<Sprite>("quely");
        queBoi[47] = Resources.Load<Sprite>("queton");
        queBoi[48] = Resources.Load<Sprite>("truongsinh");
        queBoi[49] = Resources.Load<Sprite>("tuongan");
        queBoi[50] = Resources.Load<Sprite>("vantho");
        queBoi[51] = Resources.Load<Sprite>("yenbinh");
        queBoi[52] = Resources.Load<Sprite>("nham_dan");
        queBoi[53] = Resources.Load<Sprite>("nham_dan");
        queBoi[54] = Resources.Load<Sprite>("nham_dan");
        queBoi[55] = Resources.Load<Sprite>("cattuong");
        queBoi[56] = Resources.Load<Sprite>("daihuu");
        queBoi[57] = Resources.Load<Sprite>("thuancan");
        queBoi[58] = Resources.Load<Sprite>("phucloc");
        queBoi[59] = Resources.Load<Sprite>("hanhthong");
        queBoi[60] = Resources.Load<Sprite>("phuquy");
        queBoi[61] = Resources.Load<Sprite>("tai_loc");
        queBoi[62] = Resources.Load<Sprite>("hanh_phuc");
        queBoi[90] = Resources.Load<Sprite>("error");

    }

    public static void ResetGameData()
    {
        theLe = null;
        ToastMessage = null;
        queBoiIndex = 0;
        queBoiDescReal = null;
        //data = null;
        collectionPrizeTime = 0;
        menuInput = true;
    }


    public static string GetTenLinhThu(string code)
    {
        switch (code)
        {
            case "CHUOT":
                return "Tý";
            case "TRAU":
                return "Sửu";
            case "HO":
                return "Dần";
            case "MEO":
                return "Mão";
            case "RONG":
                return "Thìn";
            case "RAN":
                return "Tỵ";
            case "NGUA":
                return "Ngọ";
            case "DE":
                return "Mùi";
            case "KHI":
                return "Thân";
            case "GA":
                return "Dậu";
            case "CHO":
                return "Tuất";
            case "LON":
                return "Hợi";
            default:
                return "";
        }
    }
}
