using Mota.Game.Languages;

namespace Mota.Game.Texts.Interact;

public class ProductNameText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "HP", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "生命药水" },
                    { ELanguages.English, "Health Poison" }
                }
            }
        },
        {
            "MHP", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "最大生命值药水" },
                    { ELanguages.English, "Max Health Poison" }
                }
            }
        }
    };
}