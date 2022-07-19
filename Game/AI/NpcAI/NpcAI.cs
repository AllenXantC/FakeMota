using Mota.Game.Interact.Interacters;

namespace Mota.Game.AI.NpcAI;

public class NpcAI : AI
{
    /// <summary>
    /// instantiate a npcAi
    /// </summary>
    /// <param name="talkers">
    /// things the npc talks</param>
    /// <param name="seller">
    /// products the npc sells</param>
    /// <param name="stageChanger">
    /// the info of stage changing</param>
    /// <param name="component">
    /// the extra components of the gate</param>
    protected NpcAI(List<Talker> talkers, Seller seller, 
        StageChanger stageChanger, List<Component.Component> component) : 
        base(talkers, null, seller, stageChanger, component)
    {
    }
}