using Mota.Game.InputManagers;
using Mota.Game.Role.Actor;
using Mota.Game.Util;

namespace Mota.Game.Logic;

public class Game : ILifeCycle
{
    private readonly World _world = new();
    private readonly StageManager _stageManager = new();
    private readonly InteractController _interactController = new();
    private readonly ChangeSettingsController _changeSettingsController = new(); 

    private void CheckGameState()
    {
        if (_world.ActorsCount[(int) EActorType.Player] == 0)
        {
            GameState.Instance.EGameState = EGameState.Lose;
        }
    }

    private bool IsEnemyAllDie()
    {
        return _world.IsAllEnemyDie();
    }
    
    private void SetStage()
    {
        if (_stageManager.IsAtFinalStage())
        {
            GameState.Instance.EGameState = EGameState.Win;
            return;
        }
        _stageManager.SetStage();
        _world.AwakeActorAndNpc();
        _world.Actors.Add(_world.Player);
    }

    public void Awake()
    {
        Debug.Log($"{GetType().Name} Awake");
        _stageManager.World = _world;
        _stageManager.Awake();
        _world.Awake();
    }

    public void Update()
    {
        Debug.Log($"{GetType().Name} Update");
        if (GameState.Instance.EGameState is EGameState.Lose or EGameState.Win)
        {
            Driver.IsFinished = true;
        }
        _world.Update();
        CheckGameState();
        _world.CommonRender();
    }

    public bool IsInteractDetect()
    {
        _world.AskIsInteract();
        return _world.IsInteract;
    }

    public bool InteractUpdate()
    {
        _world.IsInteract = false;
        _world.SetInteractInformation(_interactController, SetStage, IsEnemyAllDie);
        _interactController.Update();
        // reset both inputManagers to avoid accidents
        IsInteractInputManager.SetZero();
        IsOpenSettingsInputManager.SetZero();
        return _world.IsInteract;
    }

    public bool IsOpenSettingDetect()
    {
        _world.AskIsOpenSettings();
        return _world.IsOpenSettings;
    }

    public bool ChangeSettings()
    {
        _world.IsOpenSettings = false;
        _changeSettingsController.Awake();
        _changeSettingsController.Update();
        // reset both inputManagers to avoid accidents
        IsInteractInputManager.SetZero();
        IsOpenSettingsInputManager.SetZero();
        return _world.IsOpenSettings;
    }
    
    public static void OnGetCommonInput(char input)
    {
        CommonInputManager.InputVec = input switch
        {
            'w' => new Vector2(0, -1),
            's' => new Vector2(0, 1),
            'a' => new Vector2(-1, 0),
            'd' => new Vector2(1, 0),
            _ => CommonInputManager.InputVec
        };
        if (input == 'g')
        {
            IsOpenSettingsInputManager.IsOpenSettings = true;
        }
    }

    public static void OnGetIsInteractInput(int i)
    {
        IsInteractInputManager.IsInteractDetectInput = i switch
        {
            1 => true,
            _ => IsInteractInputManager.IsInteractDetectInput
        };
    }
}