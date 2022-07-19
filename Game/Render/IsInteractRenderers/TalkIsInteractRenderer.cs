using Mota.Game.Texts.Interact;
using Mota.Game.Util;

namespace Mota.Game.Render.IsInteractRenderers;

public class TalkIsInteractRenderer : IRenderIsInteract
{
    public void RenderIsInteract(AskInteractText text)
    {
        Console.WriteLine(text.TextWithLans["ChangeStage"]);
    }
}