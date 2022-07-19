using Mota.Game.AI.ActorAI;
using Mota.Game.Interact.Interacters;
using Mota.Game.Languages;

namespace Mota.Game.Role.Actor;

public class Actor : Role
{
    public double MaxHealth { get; set; }
    private double _health;

    public double Health
    {
        get => _health;
        set => _health = GetValidHealth(value);
    }
    public int Damage { get; set; }
    public int Dodge { get; set; }
    public int Exp { get; set; }
    public int Coin { get; set; }
    public virtual int Type => 0;

    private double GetValidHealth(double health)
    {
        return health > MaxHealth ? MaxHealth : health;
    }

    protected Actor(TextWithLan name, TextWithLan renderName, double maxHealth, 
        int damage, int dodge, int exp, int coin, ActorAI actorAi, 
        EInteracterType type) : base(name, renderName, actorAi, type)
    {
        MaxHealth = maxHealth;
        Health = MaxHealth;
        Damage = damage;
        Dodge = dodge;
        Exp = exp;
        Coin = coin;
    }
}