using Mota.Game.Languages;

namespace Mota.Game.Texts.Settings;

public class AskIsOpenSettingsText : Text
{
    public static readonly TextWithLan IsOpenSettings = new()
    {
        Texts =
        {
            { ELanguages.Chinese, "要打开设置吗？（按g）" },
            { ELanguages.English, "Open the settings? (press g)" }
        }
    };
}