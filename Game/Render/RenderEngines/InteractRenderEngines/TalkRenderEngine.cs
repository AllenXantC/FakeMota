using Mota.Game.Interact.Interacters;

namespace Mota.Game.Render.RenderEngines.InteractRenderEngines;

public class TalkRenderEngine : InteractRenderEngine
{
    public void RenderTalk(Role.Role role, Talker talker)
    {
        Console.WriteLine();
        Console.WriteLine($"{role.Name}: {talker.Talk}");
        Thread.Sleep(1000);
    }
}