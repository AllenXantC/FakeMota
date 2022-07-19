using Mota.Game.Languages;

namespace Mota.Game.Texts.Settings;

public class ChangeLanguagesText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "ChooseLanguage", new TextWithLan
            {
                Texts =
                {
                    {
                        ELanguages.Chinese,
                        "选择你想使用的语言："
                    },
                    {
                        ELanguages.English,
                        "Choose the language you would like to use:"
                    }
                }
            }
        },
        {
            "Chinese", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "中文" },
                    { ELanguages.English, "Chinese" }
                }
            }
        },
        {
            "English", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "英文" },
                    { ELanguages.English, "English" }
                }
            }
        }
    };
}