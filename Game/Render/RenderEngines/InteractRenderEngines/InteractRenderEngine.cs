using Mota.Game.Languages;

namespace Mota.Game.Render.RenderEngines.InteractRenderEngines;

public class InteractRenderEngine : RenderEngine
{
    protected static bool IsChinese()
    {
        return LanguageManager.ELanguage == ELanguages.Chinese;
    }
}