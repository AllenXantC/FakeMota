using Mota.Game.Languages;

namespace Mota.Game.Texts.Interact;

public class AskInteractText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "TheOneNear", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "在你旁边的是：" },
                    { ELanguages.English, "The one near you is " }
                }
            }
        },
        {
            "Yes", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "1、好" },
                    { ELanguages.English, "1. Yes" }
                }
            }
        },
        {
            "Talk", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "与他/她对话？" },
                    { ELanguages.English, "Talk to him/ her?" }
                }
            }
        },
        {
            "Battle", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "与他/她对战？" },
                    { ELanguages.English, "Fight against him/ her?" }
                }
            }
        },
        {
            "Sell", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "进入购物？" },
                    { ELanguages.English, "Get in and shop?" }
                }
            }
        },
        {
            "ChangeStage", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "去下一层？" },
                    { ELanguages.English, "Go to the next stage?" }
                }
            }
        }
    };
}