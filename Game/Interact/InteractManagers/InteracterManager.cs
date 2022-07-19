using Mota.Game.Util;

namespace Mota.Game.Interact.InteractManagers;

public class InteracterManager
{
    /// <summary>
    /// called once when the player and the role are interacting
    /// </summary>
    /// <param name="interactMessage"></param>
    /// <param name="player"></param>
    /// <param name="target"></param>
    /// <param name="render"></param>
    public virtual void InteractUpdate(InteractMessage interactMessage,
        Role.Role player, Role.Role target, InteractRenderManager render)
    {
        
    }

    public virtual void Awake(Func<bool> isEnemyAllDie, Action setStage)
    {
        Debug.Log($"{GetType().Name} Awake");
    }
}