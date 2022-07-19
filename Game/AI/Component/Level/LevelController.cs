using Mota.Game.Role.Actor;
using Mota.Game.Texts;
using Mota.Game.Texts.Component;
using Mota.Game.Util;

namespace Mota.Game.AI.Component.Level;

public class LevelController : Component
{
    private int Level { get; set; }
    private Level _level;

    /// <summary>
    /// used for setting a text
    /// </summary>

    public override void Awake()
    {
        Level = 1;
        SetLevel();
        _level.Bind(Role);
        OutputText = new LevelControllerText();
        OriginalText = OutputText.Clone() as Text;
        SetText();
    }

    public override void Update()
    {
        if (!IsNextLevel()) return;
        _level.ChangeProperties();
        Level++;
        SetLevel();
        _level.Bind(Role);
        SetText();
    }

    /// <summary>
    /// make _level the instance of the first (or the next) Level
    /// </summary>
    private void SetLevel()
        // let _level become the instance of the class Level
    {
        var levelName = "Level" + Level;
        _level = GetType().Assembly.CreateInstance
            ($"Mota.Game.AI.Component.Level.{levelName}") as Level;
    }
        
    /// <summary>
    /// judge if the exp is high enough for getting into the next level
    /// </summary>
    /// <returns></returns>
    private bool IsNextLevel()
    {
        var player = Role as Player;
        return player?.Exp >= _level.ExpUpperBound;
    }

    /// <summary>
    /// text before this method called: "Level: "
    /// text after this method called: "Level: 1"
    /// </summary>
    public override void SetText()
    {
        // make a clone of OriginalTextWithLans
        var textWithLans = 
            CloneUtil.CloneDictionaryTextWithLan(OriginalText.TextWithLans);
        for (var i = 0; i < textWithLans.Count; i++)
        {
            var strKey = textWithLans.Keys.ElementAt(i);
            var textWithLan = textWithLans[strKey];
            var texts = textWithLan.Texts;
            switch (strKey)
            {
                case "Level": 
                    for (var j = 0; j < texts.Count; j++) 
                    {
                        var languageKey = texts.Keys.ElementAt(j);
                        texts[languageKey] += $"{Level}";
                    }

                    break;
            }
        }

        OutputText.TextWithLans = textWithLans;
    }

    public override string ToString()
    {
        return OutputText.TextWithLans["Level"].ToString();
    }
}