using Mota.Game.AI.NpcAI;
using Mota.Game.Interact.Interacters;
using Mota.Game.Languages;

namespace Mota.Game.Role.NPC;

public class Shop : NPC
{
    public Shop(TextWithLan name, TextWithLan renderName, ShopAI shopAi,
        EInteracterType type) : base(name, renderName, shopAi, type)
    {
        
    }
}