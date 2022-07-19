using Mota.Game.Languages;

namespace Mota.Game.Texts.GameOpener;

public class GameOpenerText
{
    public static TextWithLan Opener = new()
    {
        Texts =
        {
            {
                ELanguages.Chinese, "小贴士：\n" +
                                    "1.\n" +
                                    "在玩家与对象交互时，第一次交互通常需要按两次，\n" +
                                    "电脑才会有反应\n" +
                                    "按回车键继续"
            },
            {
                ELanguages.English, "Tips:\n" +
                                    "1.\n" +
                                    "After player and a non-player role start to interact, \n" +
                                    "the button usually need to be pressed twice initially, \n" +
                                    "then the program can receive that\n" +
                                    "Got it? Press ENTER"
            }
        }

    };
}