using Mota.Game.Texts.GameOpener;

namespace Mota.Game.Render.RenderEngines;

public class GameOpenerRenderEngine : RenderEngine
{
    public static void Open()
    {
        Console.WriteLine(GameOpenerText.Opener);
    }
}