using System.Text;
using Mota.Game.Item;
using Mota.Game.Role.Actor;
using Mota.Game.Texts;
using Mota.Game.Texts.Interact;
using Mota.Game.Util;

namespace Mota.Game.Render.RenderEngines.InteractRenderEngines;

public class BattleRenderEngine : InteractRenderEngine
{
    public void RenderBattleOpener(Role.Role role)
    {
        Console.WriteLine();
        SetBattleOpenerText(role);
        Console.WriteLine(OutputText.TextWithLans["FightAgainst"]);
    }

    private void SetBattleOpenerText(Role.Role role)
    {
        var textWithLans = 
            CloneUtil.CloneDictionaryTextWithLan(OriginalText.TextWithLans);
        var texts = textWithLans["FightAgainst"].Texts;
        for (var i = 0; i < texts.Count; i++)
        {
            var languageKey = texts.Keys.ElementAt(i);
            texts[languageKey] += $"{role.Name}" + (IsChinese() ? "！" : "!");
        }

        OutputText.TextWithLans["FightAgainst"] = textWithLans["FightAgainst"];
    }
    
    public void RenderBattleOrder(Role.Role role)
    {
        SetBattleOrderText(role);
        Console.Write(OutputText.TextWithLans["InThisRound"]);
        Console.WriteLine(OutputText.TextWithLans["IsGonnaAttack"]);
        Thread.Sleep(1000);
    }

    private void SetBattleOrderText(Role.Role role)
    {
        var textWithLans = 
            CloneUtil.CloneDictionaryTextWithLan(OriginalText.TextWithLans);
        var texts = textWithLans["InThisRound"].Texts;
        for (var i = 0; i < texts.Count; i++)
        {
            // "In this round, XXX is gonna attack!"
            var languageKey = texts.Keys.ElementAt(i);
            texts[languageKey] += $"{role.Name}";
        }
        
        OutputText.TextWithLans = textWithLans;
    }
    
    public void RenderBattleItemOptions(List<Skill> skills, Player player)
    {
        var i = 1;
        var sb = new StringBuilder();
        if (skills != null)
        {
            GetSkillsOptionsRenderInfos(sb, skills, ref i);
        }
        GetProductsOptionsRenderInfos(sb, player.GetProductsDictionary(), ref i);
        Console.WriteLine();
        Console.WriteLine(sb.ToString());
        Thread.Sleep(1000);
    }

    private void GetSkillsOptionsRenderInfos(StringBuilder sb, 
        List<Skill> skills, ref int i)
    {
        foreach (var skill in skills)
        {
            // $"{i}. {skill.Name}. "
            sb.Append($"{i}");
            sb.Append(IsChinese() ? "、" : ". ");
            sb.Append($"{skill.Name}. ");
            i++;
        }
    }
    
    private void GetProductsOptionsRenderInfos(
        StringBuilder sb, Dictionary<Product, int> dic, ref int i)
    {
        if (dic.Count == 0) return;
        sb.Append('\n');
        sb.Append(OriginalText.TextWithLans["ProductsFromShop"]);
        foreach (var productNumPair in dic)
        {
            // sb.Append(
            //     $"{i}. {productNumPair.Key.Name} {productNumPair.Value} available. ");
            sb.Append($"{i}");
            sb.Append(IsChinese() ? "、" : ". ");
            sb.Append($"{productNumPair.Key.Name} {productNumPair.Value} ");
            sb.Append(OutputText.TextWithLans["Available"]);
            i++;
        }
    }

    public void RenderBattleInfo(Actor actor, Item.Item item)
    {
        SetBattleInfo(item);
        // Console.WriteLine($"{actor.Name} used {item.Name}！");
        Console.WriteLine($"{actor.Name}" + OutputText.TextWithLans["Used"]);
        Thread.Sleep(1000);
    }

    private void SetBattleInfo(Item.Item item)
    {
        var textWithLans = 
            CloneUtil.CloneDictionaryTextWithLan(OriginalText.TextWithLans);
        var texts = textWithLans["Used"].Texts;
        for (var i = 0; i < texts.Count; i++)
        {
            var languageKey = texts.Keys.ElementAt(i);
            texts[languageKey] += $"{item.Name}" + (IsChinese() ? "！" : "!");
        }
        
        OutputText.TextWithLans = textWithLans;
    }
    
    public void RenderTargetInfo(Actor target)
    {
        // set the target's text to print the most up-to-date data
        // target.SetText();
        Console.WriteLine(target.ToString());
        Thread.Sleep(1000);
    }

    public void RenderEnemyDeath(Actor enemy)
    {
        Console.WriteLine();
        Console.WriteLine($"{enemy.Name}" + OutputText.TextWithLans["Defeated"]);
        Thread.Sleep(1000);
    }

    public override void Awake()
    {
        base.Awake();
        OutputText = new BattleText();
        OriginalText = OutputText.Clone() as Text;
    }
}