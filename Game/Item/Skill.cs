using Mota.Game.Languages;
using Mota.Game.Role.Actor;

namespace Mota.Game.Item;

public class Skill : Item
{
    /// <summary>
    /// the first Actor in the parameters of UseSkill is the attacker
    /// and the second one is the target
    /// </summary>
    public readonly Func<Actor, Actor, bool> UseSkill;

    public Skill(TextWithLan name, Func<Actor, Actor, bool> useSkill)
    {
        Name = name;
        UseSkill = useSkill;
    }
}