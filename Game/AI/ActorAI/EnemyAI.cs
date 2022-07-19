using Mota.Game.Interact.Interacters;

namespace Mota.Game.AI.ActorAI;

public class EnemyAI : ActorAI
{
    /// <summary>
    /// instantiate an enemyAi
    /// </summary>
    /// <param name="talkers">
    /// words the enemy talks</param>
    /// <param name="battler">
    /// the battle info of the enemy</param>
    /// <param name="component">
    /// the extra components of the enemy</param>
    public EnemyAI(List<Talker> talkers, Battler battler, 
        List<Component.Component> component) : 
        base(talkers, battler, component)
    {
    }
}