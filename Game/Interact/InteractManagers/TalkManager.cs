using Mota.Game.Interact.Interacters;

namespace Mota.Game.Interact.InteractManagers;

public class TalkManager : InteracterManager
{
    public override void InteractUpdate(InteractMessage interactMessage, 
        Role.Role player, Role.Role target, InteractRenderManager render)
    {
        var targetTalkers = target.AI.GetTalkers();
        var talker = targetTalkers[interactMessage.Order];
        Talk(target, talker, render);
    }
    
    private static void Talk(Role.Role role, Talker talker, 
        InteractRenderManager render)
    {
        render.RenderTalk(role, talker);
    }
}