using Mota.Game.Languages;

namespace Mota.Game.Texts.Settings;

public class SettingsText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "Language", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "语言" },
                    { ELanguages.English, "Language" }
                }
            }
        },
        {
            "Exit", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "退出" },
                    { ELanguages.English, "Exit" }
                }
            }
        }
    };
}