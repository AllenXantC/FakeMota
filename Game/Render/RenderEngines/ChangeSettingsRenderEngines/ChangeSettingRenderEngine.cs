using Mota.Game.Languages;

namespace Mota.Game.Render.RenderEngines.ChangeSettingsRenderEngines;

public class ChangeSettingRenderEngine : RenderEngine
{
    protected static bool IsChinese()
    {
        return LanguageManager.ELanguage == ELanguages.Chinese;
    }
}