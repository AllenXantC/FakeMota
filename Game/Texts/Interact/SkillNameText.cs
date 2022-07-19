using Mota.Game.Languages;

namespace Mota.Game.Texts.Interact;

public class SkillNameText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "GA", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "普通攻击" },
                    { ELanguages.English, "General Attack" }
                }
            }
        },
        {
            "DOE", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "闪避值提升" },
                    { ELanguages.English, "Dodge Enhance" }
                }
            }
        },
        {
            "DAE", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "攻击力提升" },
                    { ELanguages.English, "Damage Enhance" }
                }
            }
        }
    };
}