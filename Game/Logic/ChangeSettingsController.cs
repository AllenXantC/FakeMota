using Mota.Game.InputManagers;
using Mota.Game.Settings;
using Mota.Game.Settings.ChangeSettingsManagers;
using Mota.Game.Util;

namespace Mota.Game.Logic;

public class ChangeSettingsController : ILifeCycle
{
    private ChangeSettingsManager _changeSettingsManager;
    private readonly SettingsRenderManager _settingsRenderManager = new();

    public void Awake()
    {
        Debug.Log($"{GetType().Name} Awake");
        _settingsRenderManager.Awake();
    }

    public void Update()
    {
        Debug.Log($"{GetType().Name} Update");
        AskWhichSettingToChange();
        if (IsLeave())
        {
            return;
        }
        var index = SettingsInputManager.SettingNumber - 1;
        var str = FindInEChangeSettingsManagerType(index);
        _changeSettingsManager = GetType().Assembly.CreateInstance
                ($"Mota.Game.Settings.ChangeSettingsManagers.{str}")
            as ChangeSettingsManager;
        _changeSettingsManager?.ChangeSettingsUpdate(_settingsRenderManager);
    }

    private void AskWhichSettingToChange()
    {
        _settingsRenderManager.RenderSettingsOptions();
        SettingsInputManager.GetSettingNumberInput(
            Enum.GetNames(typeof(EChangeSettingsManagerType)).Length + 1);
    }
    
    private string FindInEChangeSettingsManagerType(int index)
    {
        var array = Enum.GetValues(typeof(EChangeSettingsManagerType));
        var obj = array.GetValue(index);
        return obj?.ToString();
    }

    private bool IsLeave()
    {
        return SettingsInputManager.SettingNumber >
               Enum.GetNames(typeof(EChangeSettingsManagerType)).Length;
    }
}