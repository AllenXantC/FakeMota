using Mota.Game.InputManagers;
using Mota.Game.Languages;

namespace Mota.Game.Settings.ChangeSettingsManagers;

public class ChangeLanguagesManager : ChangeSettingsManager
{
    public override void ChangeSettingsUpdate(SettingsRenderManager render)
    {
        render.RenderLanguagesOptions();
        SettingsInputManager.GetLanguageNumberInput(
            Enum.GetNames(typeof(ELanguages)).Length);
        var index = SettingsInputManager.LanguageNumber - 1;
        LanguageManager.ELanguage = (ELanguages)FindInELanguages(index);
    }
    
    private static object FindInELanguages(int index)
    {
        var array = Enum.GetValues(typeof(ELanguages));
        var obj = array.GetValue(index);
        return obj;
    }
}