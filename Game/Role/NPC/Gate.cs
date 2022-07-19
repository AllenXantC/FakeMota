using Mota.Game.AI.NpcAI;
using Mota.Game.Interact.Interacters;
using Mota.Game.Languages;

namespace Mota.Game.Role.NPC;

public class Gate : NPC
{
    public Gate(TextWithLan name, TextWithLan renderName, GateAI gateAi,
        EInteracterType type) : base(name, renderName, gateAi, type)
    {
            
    }
}