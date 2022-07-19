using Mota.Game.Languages;

namespace Mota.Game.Texts.Interact;

public class TalkText : Text
{
    public override Dictionary<string, TextWithLan> TextWithLans { get; set; } = new()
    {
        {
            "Csb0", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "你也好！" },
                    { ELanguages.English, "Hello!" }
                }
            }
        },
        {
            "Zbb0", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese, "你好！" },
                    { ELanguages.English, "Hi!" }
                }
            }
        },
        {
            "Gxq0", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese , "你好！"},
                    { ELanguages.English , "Hello!"}
                }
            }
        },
        {
            "Khrushchev0", new TextWithLan
            {
                Texts =
                {
                    { ELanguages.Chinese , "我要让你一辈子种玉米！"},
                    { ELanguages.English , "I'll make you grow corns for life!"}
                }
            }
        }
    };
}