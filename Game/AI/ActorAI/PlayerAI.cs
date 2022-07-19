using Mota.Game.InputManagers;
using Mota.Game.Interact.Interacters;
using Mota.Game.Util;

namespace Mota.Game.AI.ActorAI;

public class PlayerAI : ActorAI
{
    /// <summary>
    /// instantiate a playerAi
    /// </summary>
    /// <param name="talkers">
    /// words the player talks</param>
    /// <param name="component">
    /// the extra components of the player</param>
    public PlayerAI(List<Talker> talkers, List<Component.Component> component) : 
        base(talkers, null, component)
    {
        
    }

    public override void Update()
    {
        base.Update();
        InputUpdate();
    }

    /// <summary>
    /// receive the InputVec from the CommonInputManager and move
    /// </summary>
    private void InputUpdate()
    {
        var dir = CommonInputManager.InputVec;
        Role.Pos += dir;
        CommonInputManager.InputVec = Vector2.Zero; // reset input
    }
}