using Mota.Game.Languages;
using Mota.Game.Render.RenderEngines;
using Mota.Game.Render.RenderEngines.ChangeSettingsRenderEngines;
using Mota.Game.Texts;
using Mota.Game.Texts.Interact;
using Mota.Game.Texts.Settings;

namespace Mota.Game.Settings;

public class SettingsRenderManager : RenderEngine
{
    private readonly ChangeLanguagesRenderEngine _languagesRender = new();

    #region CalledByChangeSettingsController

    /// <summary>
    /// the return value means the number of the options
    /// </summary>
    public void RenderSettingsOptions()
    {
        var i = 1;
        foreach (var obj in Enum.GetValues(typeof(ESettingsType)))
        {
            var str = obj.ToString();
            Console.Write($"{i}" + (IsChinese() ? "、" : ". ") +
                          $"{OutputText.TextWithLans[str ?? string.Empty]}" +
                          "   ");
            i++;
        }

        Console.WriteLine($"{i}" + (IsChinese() ? "、" : ". ") +
                          $"{OutputText.TextWithLans["Exit"]}" + "   ");
    }

    public static void RenderInvalidInput()
    {
        Console.WriteLine();
        Console.WriteLine(InvalidInputText.InvalidInput);
    }
    
    private static bool IsChinese()
    {
        return LanguageManager.ELanguage == ELanguages.Chinese;
    }

    #endregion

    #region CalledByChangeLanguagesManager

    public void RenderLanguagesOptions()
    {
        _languagesRender.RenderLanguagesOptions();
    }

    #endregion
    
    public override void Awake()
    {
        base.Awake();
        
        _languagesRender.Awake();
        
        OutputText = new SettingsText();
        // OriginalText = OutputText.Clone() as Text;
    }
}