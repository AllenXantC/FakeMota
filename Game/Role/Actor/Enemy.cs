using System.Text;
using Mota.Game.AI.ActorAI;
using Mota.Game.Interact.Interacters;
using Mota.Game.Languages;
using Mota.Game.Texts;
using Mota.Game.Texts.Role;
using Mota.Game.Util;

namespace Mota.Game.Role.Actor;

public class Enemy : Actor
{
    public int Score { get; }
    public override int Type => (int) EActorType.Enemy;

    public override string ToString()
    {
        SetText();
        // var str = "Enemy info: " + $"Name: {Name}\n" +
        //           $"MaxHealth: {MaxHealth}  Health: {Health}\n" +
        //           $"Damage: {Damage}  Dodge: {Dodge}\n";
        // return str;
        var sb = new StringBuilder();
        var textWithLans = OutputText.TextWithLans;
        #region Assigning Variables

        var enemyInfo = textWithLans["EnemyInfo"];
        var name = textWithLans["Name"];
        var maxHealth = textWithLans["MaxHealth"];
        var health = textWithLans["Health"];
        var damage = textWithLans["Damage"];
        var dodge = textWithLans["Dodge"];

        #endregion

        sb.Append(enemyInfo.ToString() + name + "\n" +
                  maxHealth + "  " + health + "\n" +
                  damage + "  " + dodge + "\n");

        return sb.ToString();
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
                case "Name":
                    for (var j = 0; j < texts.Count; j++)
                    {
                        var languageKey = texts.Keys.ElementAt(j);
                        texts[languageKey] += $"{Name.Texts[languageKey]}";
                    }
                    
                    break;
                case "MaxHealth":
                    for (var j = 0; j < texts.Count; j++)
                    {
                        var languageKey = texts.Keys.ElementAt(j);
                        texts[languageKey] += $"{MaxHealth}";
                    }
                    
                    break;
                case "Health":
                    for (var j = 0; j < texts.Count; j++)
                    {
                        var languageKey = texts.Keys.ElementAt(j);
                        texts[languageKey] += $"{Health}";
                    }
                    
                    break;
                case "Damage":
                    for (var j = 0; j < texts.Count; j++)
                    {
                        var languageKey = texts.Keys.ElementAt(j);
                        texts[languageKey] += $"{Damage}";
                    }
                    
                    break;
                case "Dodge":
                    for (var j = 0; j < texts.Count; j++)
                    {
                        var languageKey = texts.Keys.ElementAt(j);
                        texts[languageKey] += $"{Dodge}";
                    }
                    
                    break;
            }
        }

        OutputText.TextWithLans = textWithLans;
    }

    public Enemy(TextWithLan name, TextWithLan renderName, double maxHealth,
        int damage, int dodge, int exp, int coin, int score, 
        EnemyAI enemyAi, EInteracterType type) : 
        base(name, renderName, maxHealth, damage, dodge, exp, coin, enemyAi, type)
    {
        Score = score;
    }

    public override void Awake()
    {
        base.Awake();
        OutputText = new EnemyText();
        OriginalText = OutputText.Clone() as Text;
        SetText();
    }
}