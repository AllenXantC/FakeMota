using Mota.Game.Languages;
using Mota.Game.Util;

namespace Mota.Game.Texts;

public class Text : ICloneable
{
    public virtual Dictionary<string, TextWithLan> TextWithLans { get; set; }

    public object Clone()
    {
        var obj = new Text
        {
            TextWithLans = CloneUtil.CloneDictionaryTextWithLan(TextWithLans)
        };
        return obj;
    }

    
}