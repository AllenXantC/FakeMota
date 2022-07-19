using Mota.Game.Languages;

namespace Mota.Game.Texts.Logic;

public class GameStateText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "State", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "状态：" },
                    { ELanguages.English, "State: " }
                }
            }
        },
        {
            "Playing", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "游戏中" },
                    { ELanguages.English, "Playing" }
                }
            }
        },
        {
            "Win", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "胜利" },
                    { ELanguages.English, "Win" }
                }
            }
        },
        {
            "Lose", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "失败" },
                    { ELanguages.English, "Lose" }
                }
            }
        },
        {
            "Score", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "分数：" },
                    { ELanguages.English, "Score: " }
                }
            }
        }
    };
}