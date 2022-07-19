using Mota.Game.AI.NpcAI;
using Mota.Game.Interact.Interacters;
using Mota.Game.Languages;

namespace Mota.Game.Role.NPC;

public class NPC : Role
{

    protected NPC(TextWithLan name, TextWithLan renderName, NpcAI npcAi, 
        EInteracterType type) : base(name, renderName, npcAi, type)
    {
        
    }
}