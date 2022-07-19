using System.Text;
using Mota.Game.AI.ActorAI;
using Mota.Game.Interact.Interacters;
using Mota.Game.Item;
using Mota.Game.Languages;
using Mota.Game.Texts;
using Mota.Game.Texts.Role;
using Mota.Game.Util;

namespace Mota.Game.Role.Actor;

public class Player : Actor
{
    public override int Type => (int) EActorType.Player;
    /// <summary>
    /// the Product is the name of the product, the int
    /// is the amount the player has.
    /// for example, _product[productA] = 3 means the
    /// player has 3 productAs
    /// </summary>
    private readonly Dictionary<Product, int> _products = new();

    public void AddProduct(Product product)
    {
        if (_products.ContainsProduct(product, out var oriProduct))
        {
            _products[oriProduct]++; 
            oriProduct.Pay();
        }
        else
        {
            _products[product] = 1;
            product.Bind(this);
            product.Pay();
        }
    }

    public void ConsumeProduct(Product product)
    {
        _products[product]--;
        
        if (_products[product] == 0)
        {
            _products.Remove(product);
        }
    }
    
    public Dictionary<Product, int> GetProductsDictionary()
    {
        return _products;
    }

    public List<Product> GetProductsList()
    {
        return new List<Product>(_products.Keys);
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
                case "Exp":
                    for (var j = 0; j < texts.Count; j++)
                    {
                        var languageKey = texts.Keys.ElementAt(j);
                        texts[languageKey] += $"{Exp}";
                    }
                    
                    break;
                
                case "Coin":
                    for (var j = 0; j < texts.Count; j++)
                    {
                        var languageKey = texts.Keys.ElementAt(j);
                        texts[languageKey] += $"{Coin}";
                    }
                    
                    break;
            }
        }

        OutputText.TextWithLans = textWithLans;
    }

    public override string ToString()
    {
        SetText();
        var playerAI = AI as PlayerAI;
        var sb = new StringBuilder();
        var textWithLans = OutputText.TextWithLans;
        #region Assigning Variables

        var playerInfo = textWithLans["PlayerInfo"];
        var name = textWithLans["Name"];
        var maxHealth = textWithLans["MaxHealth"];
        var health = textWithLans["Health"];
        var damage = textWithLans["Damage"];
        var dodge = textWithLans["Dodge"];
        var exp = textWithLans["Exp"];
        var coin = textWithLans["Coin"];
        var components = textWithLans["Components"];

        #endregion

        sb.Append(playerInfo.ToString() + name + "\n" +
                  maxHealth + "  " + health + "\n" +
                  damage + "  " + dodge + "\n" +
                  exp + "  " + coin + "\n");
        sb.Append(components + "\n");
        var playerAIComponents = playerAI?.GetComponents();
        if (playerAIComponents == null) return sb.ToString();
        foreach (var component in playerAIComponents)
        {
            sb.Append(component);
            sb.Append("  ");
        }

        return sb.ToString();
    }

    public override void Awake()
    {
        base.Awake();
        OutputText = new PlayerText();
        OriginalText = OutputText.Clone() as Text;
        SetText();
    }

    public override void Update()
    {
        base.Update();
        SetText();
    }

    public Player(TextWithLan name, TextWithLan renderName, double maxHealth, 
        int damage, int dodge, PlayerAI playerAI, EInteracterType type,
        int exp = 0, int coin = 0) : base(name, renderName, maxHealth, damage, 
        dodge, exp, coin, playerAI, type)
    {
            
    }
}