namespace Mota.Game.Languages;

public static class LanguageConsole
{
    private static ELanguages _index;

    public static string GetText(TextWithLan text)
    {
        _index = GetKey();
        var str = text.Texts[_index];
        return str;
    }
    
    private static ELanguages GetKey()
    {
        return LanguageManager.ELanguage;
    }
}