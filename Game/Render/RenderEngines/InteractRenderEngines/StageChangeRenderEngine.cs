using Mota.Game.Texts;
using Mota.Game.Texts.Interact;

namespace Mota.Game.Render.RenderEngines.InteractRenderEngines;

public class StageChangeRenderEngine : InteractRenderEngine
{
    public void RenderCannotGoToNextStage()
    {
        Console.WriteLine(OutputText.TextWithLans["UndefeatedEnemies"]);
        Console.WriteLine(OutputText.TextWithLans["GotIt?"]);
        Console.ReadLine();
    }
    
    public override void Awake()
    {
        base.Awake();
        OutputText = new StageChangeText();
        // OriginalText = OutputText.Clone() as Text;
    }
}