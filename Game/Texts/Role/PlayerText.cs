using Mota.Game.Languages;

namespace Mota.Game.Texts.Role;

public class PlayerText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "PlayerInfo", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "玩家信息：" },
                    { ELanguages.English, "Player info: " }
                }
            }
        },
        {
            "Name", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "名字：" },
                    { ELanguages.English, "Name: " }
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
        },
        {
            "Exp", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "经验值：" },
                    { ELanguages.English, "Exp: " }
                }
            }
        },
        {
            "Coin", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "金币：" },
                    { ELanguages.English, "Coin: " }
                }
            }
        },
        {
            "Components", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "组件：" },
                    { ELanguages.English, "Components: " }
                }
            }
        }
    };
}