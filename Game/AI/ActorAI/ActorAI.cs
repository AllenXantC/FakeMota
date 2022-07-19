using Mota.Game.Interact.Interacters;

namespace Mota.Game.AI.ActorAI;

public class ActorAI : AI
{
    /// <summary>
    /// instantiate an actorAi
    /// </summary>
    /// <param name="talkers">
    /// words the actor talks</param>
    /// <param name="battler">
    /// the battle info of the actor</param>
    /// <param name="component">
    /// extra components of the actor</param>
    protected ActorAI(List<Talker> talkers, Battler battler, 
        List<Component.Component> component) : 
        base(talkers, battler, null, null, component)
    {
        
    }
}