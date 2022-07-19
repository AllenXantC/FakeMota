using Mota.Game.Languages;

namespace Mota.Game.Texts.Interact;

public class BattleText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "FightAgainst", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "对战" },
                    { ELanguages.English, "Fight against " }
                }
            }
        },
        {
            "InThisRound", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "在这一回合，" },
                    { ELanguages.English, "In this round, " }
                }
            }
        },
        {
            "IsGonnaAttack", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "将要出招！" },
                    { ELanguages.English, " is gonna attack!" }
                }
            }
        },
        {
            "ProductsFromShop", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "从商店里买来的东西（敌人用不了） " },
                    { ELanguages.English, "Products bought from the shop: (enemies can't use) " }
                }
            }
        },
        {
            "Available", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "可用. " },
                    { ELanguages.English, "available. " }
                }
            }
        },
        {
            "Invalid", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "输入有误！" },
                    { ELanguages.English, "Invalid input!" }
                }
            }
        },
        {
            "Used", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "使用了" },
                    { ELanguages.English, " used " }
                }
            }
        },
        {
            "Defeated", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "被打败了！" },
                    { ELanguages.English, " has been defeated!" }
                }
            }
        }
    };
}