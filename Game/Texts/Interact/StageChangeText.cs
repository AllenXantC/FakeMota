using Mota.Game.Languages;

namespace Mota.Game.Texts.Interact;

public class StageChangeText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "UndefeatedEnemies", new TextWithLan
            {
                Texts =
                {
                    {
                        ELanguages.Chinese,
                        "当前层中还有未被击败的敌人！"
                    },
                    {
                        ELanguages.English,
                        "There are still undefeated enemies in the current stage!"
                    }
                }
            }
        },
        {
            "GotIt?", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "按回车键继续" },
                    { ELanguages.English, "Got it? Press ENTER" }
                }
            }
        }
    };
}