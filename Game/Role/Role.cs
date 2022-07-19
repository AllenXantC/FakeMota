using Mota.Game.Interact.Interacters;
using Mota.Game.Languages;
using Mota.Game.Logic;
using Mota.Game.Texts;
using Mota.Game.Util;

namespace Mota.Game.Role;

public class Role : TextUser
{
    public TextWithLan Name { get; }
    public TextWithLan RenderName { get; }
    private Vector2 _pos;
    public Vector2 Pos
    {
        get => _pos;
        set => _pos = World.GetValidPos(value);
    }

    public AI.AI AI { get; }

    /// <summary>
    /// used when asking the player whether to interact with the role,
    /// for example, "Talk to ..." when it's EInteracterType.Talk
    /// </summary>
    public readonly EInteracterType EInteracterType;

    protected Role(TextWithLan name, TextWithLan renderName, AI.AI ai, 
        EInteracterType type)
    {
        Name = name;
        RenderName = renderName;
        Pos = World.GetRandomPos();
        AI = ai;
        ai.Bind(this);
        EInteracterType = type;
    }
        
    public override void Awake()
    {
        Debug.Log($"{GetType().Name} Awake");
        AI.Awake();
    }

    public override void Update()
    {
        Debug.Log($"{GetType().Name} Update");
        AI.Update();
    }
}