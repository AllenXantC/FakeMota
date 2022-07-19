using Mota.Game.Item;

namespace Mota.Game.Interact.Interacters;

/// <summary>
/// battle info
/// </summary>
public class Battler
{
    public readonly List<Skill> Skills;

    public Battler(List<Skill> skills)
    {
        Skills = skills;
    }
}