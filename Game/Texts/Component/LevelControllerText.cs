using Mota.Game.Languages;

namespace Mota.Game.Texts.Component;

public class LevelControllerText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "Level", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "等级：" },
                    { ELanguages.English, "Level: " }
                }
            }
        }
    };
}