using Mota.Game.Interact.Interacters;

namespace Mota.Game.AI.NpcAI;

public class GateAI : NpcAI
{
    /// <summary>
    /// instantiate a gateAi
    /// </summary>
    /// <param name="talkers">
    /// things the gate “says”</param>
    /// <param name="stageChanger">
    /// the info of stage changing</param>
    /// <param name="component">
    /// the extra components of the gate</param>
    public GateAI(List<Talker> talkers, StageChanger stageChanger, 
        List<Component.Component> component) : 
        base(talkers, null, stageChanger, component)
    {
    }
}