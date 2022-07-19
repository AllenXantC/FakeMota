namespace Mota.Game.Interact.InteractManagers;

public class StageChangeManager : InteracterManager
{
    private Func<bool> _isEnemyAllDie;
    private Action _changeStage;

    public override void InteractUpdate(InteractMessage interactMessage, 
        Role.Role player, Role.Role target, InteractRenderManager render)
    {
        if (_isEnemyAllDie.Invoke())
        {
            OnChangeStage();
            return;
        }
        render.RenderCannotGoToNextStage();
    }

    private void OnChangeStage()
    {
        _changeStage?.Invoke();
    }

    public override void Awake(Func<bool> isEnemyAllDie, Action setStage)
    {
        base.Awake(isEnemyAllDie, setStage);
        _isEnemyAllDie = isEnemyAllDie;
        _changeStage = setStage;
    }
}