using Mota.Game.Languages;

namespace Mota.Game.Texts.Interact;

public static class InvalidInputText
{
    public static readonly TextWithLan InvalidInput = new()
    {
        Texts =
        {
            { ELanguages.Chinese, "输入有误！" },
            { ELanguages.English, "Invalid input!" }
        }
    };
}