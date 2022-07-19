using Mota.Game.Settings;

namespace Mota.Game.InputManagers;

public static class SettingsInputManager
{
    public static int SettingNumber;
    public static int LanguageNumber;
    
    public static void GetSettingNumberInput(int max)
    {
        var getInputTask = Task.Run(() =>
        {
            GetInput(ref SettingNumber, max);
        });
        getInputTask.Wait();
    }

    public static void GetLanguageNumberInput(int max)
    {
        var getInputTask = Task.Run(() =>
        {
            GetInput(ref LanguageNumber, max);
        });
        getInputTask.Wait();
    }
    
    private static void GetInput(ref int target, int max)
    {
        GetConsoleKey(ref target);
        while (!IsInputValid(target, max, 1))
        {
            SettingsRenderManager.RenderInvalidInput();
            GetConsoleKey(ref target);
        }
    }
    
    private static void GetConsoleKey(ref int i)
    {
        var input = Console.ReadKey();
        var ch = input.KeyChar;
        i = Convert.ToInt32(ch) - 48;
    }
    
    private static bool IsInputValid(int target, int max, int min)
    {
        return target <= max && target >= min;
    }
}