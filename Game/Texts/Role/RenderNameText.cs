using Mota.Game.Languages;

namespace Mota.Game.Texts.Role;

public class RenderNameText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "Csb", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "蔡" },
                    { ELanguages.English, "C" }
                }
            }
        },
        {
            "Zbb", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "周" },
                    { ELanguages.English, "Z" }
                }
            }
        },
        {
            "Gxq", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "顾" },
                    { ELanguages.English, "G" }
                }
            }
        },
        {
            "Khrushchev", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "玉" },
                    { ELanguages.English, "K" }
                }
            }
        },
        {
            "Shop", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "店" },
                    { ELanguages.English, "S" }
                }
            }
        },
        {
            "Gate", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "门" },
                    { ELanguages.English, "G" }
                }
            }
        }
    };
}