using Mota.Game.Texts.Settings;

namespace Mota.Game.Render.RenderEngines.ChangeSettingsRenderEngines;

public class ChangeLanguagesRenderEngine : ChangeSettingRenderEngine
{
    public void RenderLanguagesOptions()
    {
        Console.WriteLine();
        Console.WriteLine(OutputText.TextWithLans["ChooseLanguage"]);

        var i = 1;
        foreach (var obj in Enum.GetValues(typeof(Languages.ELanguages)))
        {
            var str = obj.ToString();
            Console.WriteLine($"{i}" + (IsChinese() ? "、" : ". ") +
                              $"{OutputText.TextWithLans[str ?? string.Empty]}" +
                              "   ");
            i++;
        }
    }

    public override void Awake()
    {
        base.Awake();
        OutputText = new ChangeLanguagesText();
        // OriginalText = OutputText.Clone() as Text;
    }
}