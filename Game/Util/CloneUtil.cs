using Mota.Game.Languages;

namespace Mota.Game.Util;

public static class CloneUtil
{
    public static Dictionary<string, TextWithLan> CloneDictionaryTextWithLan(
        Dictionary<string, TextWithLan> dic)
    {
        var ansDic = new Dictionary<string, TextWithLan>();
        for (var i = 0; i < dic.Count; i++)
        {
            var key = dic.Keys.ElementAt(i);
            ansDic[key] = dic[key].Clone() as TextWithLan;
        }

        return ansDic;
    }
}