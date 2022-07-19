using System.Text;
using Mota.Game.Texts;
using Mota.Game.Texts.Logic;
using Mota.Game.Util;

namespace Mota.Game.Logic;

public class GameState : TextUser
{
    public static GameState Instance { get; private set; } = new();

    private GameState()
    {
        
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var textWithLans = OutputText.TextWithLans;
        var state = textWithLans["State"];
        var score = textWithLans["Score"];
        sb.Append(state + "    " + score);
        
        return sb.ToString();

        // return $"State: {EGameState}    Score: {Score}";
    }

    public override void SetText()
    {
        var textWithLans =
            CloneUtil.CloneDictionaryTextWithLan(OriginalText.TextWithLans);
        for (var i = 0; i < textWithLans.Count; i++)
        {
            var strKey = textWithLans.Keys.ElementAt(i);
            var textWithLan = textWithLans[strKey];
            var texts = textWithLan.Texts;
            switch (strKey)
            {
                case "State":
                    switch (EGameState)
                    {
                        case EGameState.Playing:
                            for (var j = 0; j < texts.Count; j++)
                            {
                                var languageKey = texts.Keys.ElementAt(j);
                                texts[languageKey] += 
                                    textWithLans["Playing"].Texts[languageKey];
                            }
                            
                            break;
                        case EGameState.Win:
                            for (var j = 0; j < texts.Count; j++)
                            {
                                var languageKey = texts.Keys.ElementAt(j);
                                texts[languageKey] += 
                                    textWithLans["Win"].Texts[languageKey];
                            }
                            
                            break;
                        case EGameState.Lose:
                            for (var j = 0; j < texts.Count; j++)
                            {
                                var languageKey = texts.Keys.ElementAt(j);
                                texts[languageKey] += 
                                    textWithLans["Lose"].Texts[languageKey];
                            }
                            
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case "Score":
                    for (var j = 0; j < texts.Count; j++)
                    {
                        var languageKey = texts.Keys.ElementAt(j);
                        texts[languageKey] += Score;
                    }
                    
                    break;
            }
        }

        OutputText.TextWithLans = textWithLans;
    }

    public override void Awake()
    {
        OutputText = new GameStateText();
        OriginalText = OutputText.Clone() as Text;
        SetText();
    }
    
    public override void Update()
    {
        SetText();
    }

    public EGameState EGameState;
    public int Score;
}