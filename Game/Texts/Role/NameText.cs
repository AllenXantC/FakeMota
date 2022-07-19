using Mota.Game.Languages;

namespace Mota.Game.Texts.Role;

public class NameText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "Csb", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "蔡思碚" },
                    { ELanguages.English, "csb" }
                }
            }
        },
        {
            "Zbb", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "周柏彬" },
                    { ELanguages.English, "zbb" }
                }
            }
        },
        {
            "Gxq", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "顾欣青" },
                    { ELanguages.English, "gxq" }
                }
            }
        },
        {
            "Khrushchev", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "玉米小夫" },
                    { ELanguages.English, "Khrushchev" }
                }
            }
        },
        {
            "Shop", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "商店" },
                    { ELanguages.English, "shop" }
                }
            }
        },
        {
            "Gate", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "大门" },
                    { ELanguages.English, "gate" }
                }
            }
        }
    };
}