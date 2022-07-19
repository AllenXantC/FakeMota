using Mota.Game.Languages;

namespace Mota.Game.Texts.Role;

public class EnemyText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "EnemyInfo", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "敌人信息：" },
                    { ELanguages.English, "Enemy Info: " }
                }
            }
        },
        {
            "Name", new TextWithLan()
            {
                Texts =
                {
                    { ELanguages.Chinese, "名字：" },
                    { ELanguages.English, "Name: " },
                }
            }
        },
        {
            "MaxHealth", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "最大生命值：" },
                    { ELanguages.English, "MaxHealth: " }
                }
            }
        },
        {
            "Health", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "生命值：" },
                    { ELanguages.English, "Health: " }
                }
            }
        },
        {
            "Damage", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "攻击力：" },
                    { ELanguages.English, "Damage: " }
                }
            }
        },
        {
            "Dodge", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "闪避值：" },
                    { ELanguages.English, "Dodge: " }
                }
            }
        }
    };
}