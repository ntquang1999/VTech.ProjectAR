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
    public static string queBoiDescReal;
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
        "Tân niên, tân phúc, tân phú quý\nTấn tài, tấn lộc, tấn bình an",
        "Xuân này hơn hẳn bao Xuân trước\nPhúc, lộc, theo chân đến tận nhà\nHạnh phúc, bình an, đời mãn nguyện\nTiền, vàng, thóc gạo ngập kho nha",
        "Năm mới chúc nhau sức khỏe nhiều\nBạc tiền rủng rỉnh thoải mái tiêu",
        "Đầu xuân năm mới an khang\nLộc về phú quý mênh mang khắp nhà",
        "Chúc bạn tết này không giống tết xưa\nLái xe hai bánh không thừa yên sau",
        "Tân niên đem lại niềm Hạnh Phúc\nXuân đến rồi hưởng trọn niềm vui",
        "Cùng chúc nhau như ý\nHứng cho tràn an khang\nChúc năm mới bình an",
        "Đầu xuân năm mới chúc BÌNH AN\nChúc luôn TUỔI TRẺ chúc AN KHANG\nChúc sang năm mới nhiều TÀI LỘC\nCông thành danh toại chúc VINH QUANG",
        "Xuân này hơn hẳn mấy xuân qua\nPhúc lộc đưa nhau đến từng nhà\nVài lời cung chúc tân niên mới\nVạn sự an khang vạn sự lành",
        "Quẻ này chưa có thơ trong kịch bản\nSẽ thêm vào sau",
        "CHÚC tặng trên đời thêm chữ Hỷ\nMỪNG vui khắp chốn cất lời ca\nNĂM tròn xin tiễn tiết đông qua\nMỚI đón xuân tươi đến mọi nhà",
        "Cầu cho mưa thuận gió hòa\nChúc cho cha mẹ khỏe ra mỗi ngày\nLo toan phiền muộn tan bay\nĐầu xuân con chúc mẹ thầy an vui!",
        "Chúc sức khỏe thuận đường thẳng tiến\nNhững nỗi buồn ta tiễn hết đi\nTrẻ sung sức, lão cười khì\nVươn vai đứng dậy Tết ni an lành",
        "Chúc cho các chị đẹp ra\nCác anh khỏe mạnh xông pha phố phường\nChúc cho các cháu dễ thương\nChúc cho tất cả bốn phương đều mừng",
        "Mùa xuân xin chúc\nKhúc ca bình an\nNăm mới phát tài\nVạn sự như ý",
        "VẠN chuyện lo toan thay đổi hết\nSự gì bế tắc thảy hanh thông\nNHƯ anh, như chị, bằng bè bạn\nÝ nguyện trọn đời đẹp ước mong",
        "Xuân sang tết đến mọi nhà\nCon chúc ông bà sức khỏe, an khang\nChúc cô chú bác giàu sang\nMột năm sung túc cười vang mỗi ngày",
        "HẠNH dung lễ nghĩa ngời tâm ngọc\nPHÚC lộc, công danh rạng ánh ngà\nCHAN chát trống kèn, Lân hợp cảnh\nHÒA đàn, tấu sáo rộn ràng ca",
        "Xuân đến ngoài hiên cả nhà ơi\nDậy thôi gà đã gáy sáng rồi",
        "Cung chúc bình an\nVạn sự tấn tới",
        "Chúc mừng năm mới\nVạn sự tấn tới",
        "Đầu xuân năm mới an khang\nLộc về phú quý mênh mang khắp nhà",
        "Cung chúc tân niên một chữ nhàn\nChúc mừng gia quyến đặng bình an",
        "Chúc chúc nhà nhà vạn sự vui\nĐầu năm tấn tới đẹp môi cười",
        "Mừng xuân gửi chúc bạn thơ ta\nSức khỏe bình an tới mọi nhà\nCuộc sống mưu sinh cùng hưởng lạc\nTết về dạo khúc nhạc tình ca",
        "Xuân về rực rỡ nắng chan hòa\nRộn rã mừng vui tiếng xuân ca",
        "Xuân sang lộc biếc tràn muôn cõi\nTết đến mai vàng trải mọi nơi",
        "Tân niên đem lại niềm Hạnh Phúc\nXuân đến rồi hưởng trọn niềm vui",
        "Phúc sinh lễ nghĩa gia đường thịnh",
        "Năm Nhâm Dần tới\nAi cũng giàu to\nSức khỏe chẳng lo\nBuồn bực xếp xó",
        "Tân niên, hạnh phúc bình an tiến\nXuân nhật, vinh hoa phú qúy lai",
        "CHÚC Tết xuân nay khắp mọi nhà\nMỪNG thọ ông bà với mẹ cha\nNĂM cũ vừa qua xin cầu chúc\nMỚI trọn tình xuân đẹp mặn mà",
        "Chúc cha mẹ làm ăn phát tài\nMừng đàn em chóng lớn, chăm ngoan\nMột năm chẳng phải lo toan\nMới mẻ đủ thứ, phụng loan sum vầy",
        "Niệm tiên tổ, duật tu quyết đức\nKhải hậu nhân,trường phát kỳ tường",
        "Chúc năm mới phát tài phát lộc\nTiền đầy kho bỗng chốc mà giàu",
        "VẠN phúc lành thay duyên vừa đủ\nSỰ nghiệp danh đề mãi thiên thu\nNHƯ trên gia hộ cho con cháu\nÝ nguyện trời ban đến tuổi già",
        "Xin mừng tết gặp niềm vui mới\nThịnh Vượng An Khang hết mọi người",
        "Gia đình hạnh phúc bè bạn quý",
        "Giao thừa kính chúc bình an\nMẹ thầy sức khỏe, ngàn ngàn xuân vui"
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
