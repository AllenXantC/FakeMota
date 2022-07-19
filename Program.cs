using Mota.Game.Languages;
using Mota.Game.Logic;
using Mota.Game.Render.RenderEngines;

namespace Mota;

internal static class Program
{
    public static void Main()
    {
        LanguageManager.ELanguage = ELanguages.Chinese;
        GameOpenerRenderEngine.Open();
        Console.ReadLine();
        var game = new Game.Logic.Game();
        game.Awake();
        GameState.Instance.Awake();
        Driver.FrameIntervalMs = 100;
        Driver.IsFinished = false;
        Driver.Drive(Game.Logic.Game.OnGetCommonInput,
            Game.Logic.Game.OnGetIsInteractInput, game.Update,
            game.IsInteractDetect, game.InteractUpdate,
            game.IsOpenSettingDetect, game.ChangeSettings);
    }
}