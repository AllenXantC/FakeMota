using System.Text;
using Mota.Game.Interact.Interacters;
using Mota.Game.Item;
using Mota.Game.Role.Actor;
using Mota.Game.Role.NPC;
using Mota.Game.Texts;
using Mota.Game.Texts.Interact;
using Mota.Game.Util;

namespace Mota.Game.Render.RenderEngines.InteractRenderEngines;

public class SellRenderEngine : InteractRenderEngine
{
    public void RenderSellOpener(Shop shop, Seller seller)
    {
        Console.WriteLine();
        SetSellOpenerText(shop);
        Console.WriteLine(OutputText.TextWithLans["Welcome"]);
        RenderSellProductOptions(seller.Products, shop);
        Thread.Sleep(1000);
    }

    private void SetSellOpenerText(Shop shop)
    {
        var textWithLans = 
            CloneUtil.CloneDictionaryTextWithLan(OriginalText.TextWithLans);
        var texts = textWithLans["Welcome"].Texts;
        
        for (var i = 0; i < texts.Count; i++)
        {
            var languageKey = texts.Keys.ElementAt(i);
            var sb = new StringBuilder();
            sb.Append($"{shop.Name}" + (IsChinese() ? "！" : "!"));
            texts[languageKey] += sb.ToString();
        }

        OutputText.TextWithLans["Welcome"] = textWithLans["Welcome"];
    }

    private void RenderSellProductOptions(List<Product> products, Shop shop)
    {
        var i = 1;
        var sb = new StringBuilder();
        if (products == null) return;
        foreach (var product in products)
        {
            // example: sb.Append($"{i}. {product.Name}: {product.Coin}   ");
            sb.Append($"{i}" + (IsChinese() ? "、" : ". ") + $"{product.Name}" +
                      (IsChinese() ? "：" : ": ") + $"{product.Coin}" + "   ");
            i++;
        }

        // example: sb.Append($"{i}. Leave {shop.Name}");
        SetLeaveText(shop);
        sb.Append($"{i}" + (IsChinese() ? "、" : ". ") + OutputText.TextWithLans["Leave"]);
        Console.WriteLine();
        Console.WriteLine(sb.ToString());
        Thread.Sleep(1000);
    }
    
    public void RenderChooseSellOptionAgain(Player player)
    {
        Console.WriteLine();
        Console.WriteLine(OutputText.TextWithLans["ChooseAnother"]);
        RenderLeftCoins(player);
    }
    
    public void RenderSellSucceed(Product product, Player player)
    {
        Console.WriteLine();
        SetSellSucceedText(product);
        Console.WriteLine(OutputText.TextWithLans["Bought"]);
        RenderLeftCoins(player);
    }

    private void SetSellSucceedText(Product product)
    {
        var textWithLans = 
            CloneUtil.CloneDictionaryTextWithLan(OriginalText.TextWithLans);
        var texts = textWithLans["Bought"].Texts;
        for (var i = 0; i < texts.Count; i++)
        {
            var languageKey = texts.Keys.ElementAt(i);
            var sb = new StringBuilder();
            sb.Append($"{product.Name}" + (IsChinese() ? "！" : "!"));
            texts[languageKey] += sb.ToString();
        }

        OutputText.TextWithLans["Bought"] = textWithLans["Bought"];
    }

    private void RenderLeftCoins(Player player)
    {
        SetLeftCoinsText(player);
        Console.WriteLine(OutputText.TextWithLans["ThereAre"]);
    }

    private void SetLeftCoinsText(Player player)
    {
        var textWithLans = 
            CloneUtil.CloneDictionaryTextWithLan(OriginalText.TextWithLans);
        var texts = textWithLans["ThereAre"].Texts;
        for (var i = 0; i < texts.Count; i++)
        {
            var languageKey = texts.Keys.ElementAt(i);
            texts[languageKey] += $"{player.Coin}" + textWithLans["LeftInYourPocket"];
        }

        OutputText.TextWithLans["ThereAre"] = textWithLans["ThereAre"];
    }

    private void SetLeaveText(Shop shop)
    {
        var textWithLans = 
            CloneUtil.CloneDictionaryTextWithLan(OriginalText.TextWithLans);
        var texts = textWithLans["Leave"].Texts;
        for (var i = 0; i < texts.Count; i++)
        {
            var languageKey = texts.Keys.ElementAt(i);
            texts[languageKey] += $"{shop.Name}";
        }

        OutputText.TextWithLans["Leave"] = textWithLans["Leave"];
    }

    public void RenderLeaveShop()
    {
        Console.WriteLine();
        Console.WriteLine(OutputText.TextWithLans["ComeAgain"]);
        Thread.Sleep(1000);
    }

    public override void Awake()
    {
        base.Awake();
        OutputText = new SellText();
        OriginalText = OutputText.Clone() as Text;
    }
}