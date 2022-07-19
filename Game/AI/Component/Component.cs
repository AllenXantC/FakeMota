using Mota.Game.Texts;
using Mota.Game.Util;

namespace Mota.Game.AI.Component;

public class Component : TextUser, IBind
{
    protected Role.Role Role;

    public void Bind(Role.Role role)
    {
        Role = role;
    }

    public override void Awake()
    {
        base.Awake();
        Debug.Log($" {GetType().Name} Awake");
    }

    public override void Update()
    {
        Debug.Log($" {GetType().Name} Update");
    }

    public override void SetText()
    {
        
    }
}