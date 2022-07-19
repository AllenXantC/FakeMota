using Mota.Game.Interact.Interacters;
using Mota.Game.Util;

namespace Mota.Game.AI;

public class AI : ILifeCycle, IBind
{
    protected Role.Role Role;
    private readonly List<Component.Component> _components;

    public virtual void Bind(Role.Role role)
    {
        Role = role;
    }
        
    /// <summary>
    /// used for storing lots of Talkers
    /// </summary>
    private List<Talker> Talkers { get; }
    private Battler Battler { get; }
    private Seller Seller { get; }
    private StageChanger StageChanger { get; }

    protected AI(List<Talker> talkers, Battler battler, Seller seller, 
        StageChanger stageChanger, List<Component.Component> components)
    {
        Talkers = talkers;
        Battler = battler;
        Seller = seller;
        StageChanger = stageChanger;
        _components = components;
    }

    public List<Talker> GetTalkers() => Talkers;

    public Battler GetBattler() => Battler;

    public Seller GetSeller() => Seller;

    public StageChanger GetStageChanger() => StageChanger;

    public List<Component.Component> GetComponents() => _components;
        
    public virtual void Awake()
    {
        Debug.Log($" {GetType().Name} Awake");
        if (_components == null) return;
        foreach (var component in _components)
        {
            component.Bind(Role);
            component.Awake();
        }
    }

    public virtual void Update()
    {
        Debug.Log($" {GetType().Name} Update");
        if (_components == null) return;
        foreach (var component in _components)
        {
            component.Update();
        }
    }
}