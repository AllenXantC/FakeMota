using Mota.Game.Languages;

namespace Mota.Game.Texts.Interact;

public class SellText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "Welcome", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "欢迎来到" },
                    { ELanguages.English, "Welcome to " }
                }
            }
        },
        {
            "Leave", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "离开" },
                    { ELanguages.English, "Leave " }
                }
            }
        },
        {
            "ChooseAnother", new TextWithLan
            {
                Texts =
                {
                    {
                        ELanguages.Chinese,
                        "这个你买不起，再挑一个！"
                    },
                    {
                        ELanguages.English,
                        "You can't afford this, choose another one!"
                    }
                }
            }
        },
        {
            "Bought", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "买到了" },
                    { ELanguages.English, "Bought the " }
                }
            }
        },
        {
            "ThereAre", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "还有" },
                    { ELanguages.English, "There are " }
                }
            }
        },
        {
            "LeftInYourPocket", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "块钱！" },
                    { ELanguages.English, " left in your pocket!" }
                }
            }
        },
        {
            "ComeAgain", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "欢迎下次光临！" },
                    { ELanguages.English, "Welcome to come again!" }
                }
            }
        }
    };
}